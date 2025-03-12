using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using TradingCompanyApp.Models;
using TradingCompanyApp.Models.Enums;

namespace TradingCompanyApp.Views
{
    public partial class RequestsForm : Form
    {
        readonly RequestType requestType;
        ApplicationDbContext context;
        Warehouse _warehouse;
        TextBox extraTextBox;
        public RequestsForm(RequestType _request)
        {
            InitializeComponent();
            requestType = _request;
            context = ApplicationDbContext.context;
            extraTextBox = new TextBox();
            extraTextBox.PlaceholderText = "Enter warehouse name";
            extraTextBox.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 50);
            extraTextBox.TextAlign = HorizontalAlignment.Center;
            extraTextBox.Size = textBox1.Size;
            switch (requestType)
            {
                case RequestType.SUPPLY:
                    label1.Text = "Supply Request";
                    break;
                case RequestType.RELEASE:
                    label1.Text = "Release Request";
                    break;
                case RequestType.TRANSFER:
                    label1.Text = "Transfer Request";
                    label2.Text = "From";
                    label2.Location = new Point(label4.Location.X, label2.Location.Y);
                    label4.Text = "To";
                    this.Controls.Add(extraTextBox);
                    break;
            }
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            _warehouse = context.Warehouses.FirstOrDefault(w => w.Name == textBox1.Text);
            if (_warehouse is null)
            {
                MessageBox.Show($"Warehouse {_warehouse} doesn't exist.");
            }
            else
            {
                switch (requestType)
                {
                    case RequestType.SUPPLY:
                        SupplyRequest supplyRequest = new SupplyRequest
                        {
                            WarehouseName = textBox1.Text.Trim(),
                            Warehouse = _warehouse,
                            SupplierId = int.Parse(textBox2.Text)
                        };
                        AddRequestItems(ref supplyRequest, ref _warehouse);
                        //_warehouse.SupplyRequests.Add(supplyRequest);
                        break;
                    case RequestType.RELEASE:
                        ReleaseRequest releaseRequest = new ReleaseRequest
                        {
                            WarehouseName = textBox1.Text,
                            Warehouse = _warehouse,
                            SupplierId = int.Parse(textBox2.Text)
                        };
                        AddRequestItems(ref releaseRequest, ref _warehouse);
                        //_warehouse.ReleaseRequests.Add(releaseRequest);
                        break;
                    case RequestType.TRANSFER:
                        TransferRequest transferRequest = new TransferRequest
                        {
                            SourceWarehouseName = textBox1.Text,
                            DestinationWarehouseName = textBox2.Text,
                            SupplierId = int.Parse(textBox2.Text)
                        };
                        AddRequestItems(ref transferRequest);
                        break;
                }
            }
            context.Warehouses.Update(_warehouse);
            context.SaveChanges();
        }

        private void AddRequestItems(ref SupplyRequest request, ref Warehouse warehouse)
        {
            if (dataGridView1.RowCount > 1)
            {
                context.WarehouseItem.Load();
                context.SupplyRequests.Load();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("Please provide the Item code");
                        return;
                    }

                    var warehouseItem = warehouse.Items
                        .FirstOrDefault(wi => wi.ItemCode == dataGridView1.Rows[i].Cells[0].Value.ToString());
                    SupplyRequestItem item = new SupplyRequestItem
                    {
                        ItemCode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        WarehouseId = warehouse.WarehouseId,
                        ProductionDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value),
                        ExpirationDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value)
                    };
                    request.Items.Add(item);
                    if (warehouseItem == null)
                    {
                        warehouseItem = new WarehouseItem
                        {
                            ItemCode = item.ItemCode,
                            Item = context.Items.Find(item.ItemCode),
                            WarehouseId = warehouse.WarehouseId,
                            Quantity = item.Quantity
                        };
                        warehouse.Items.Add(warehouseItem);
                    }
                    else
                    {
                        warehouseItem.Quantity += item.Quantity;
                    }

                }
            }
            warehouse.SupplyRequests.Add(request);
            context.Warehouses.Update(warehouse);

            context.SaveChanges();
        }

        private void AddRequestItems(ref ReleaseRequest request, ref Warehouse warehouse)
        {
            if (dataGridView1.RowCount > 1)
            {
                context.WarehouseItem.Load();
                context.ReleaseRequests.Load();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("Please provide the Item code");
                        break;
                    }
                    var warehouseItem = warehouse.Items
                                    .FirstOrDefault(wi => wi.ItemCode == dataGridView1.Rows[i].Cells[0].Value.ToString());
                    ReleaseRequestItem item = new ReleaseRequestItem
                    {
                        ItemCode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        WarehouseId = warehouse.WarehouseId
                    };
                    request.Items.Add(item);
                    if (warehouseItem == null || warehouseItem.Quantity < item.Quantity)
                    {
                        MessageBox.Show($"Not enough stock for item {item.ItemCode}.");
                        return;
                    }
                    warehouseItem.Quantity -= item.Quantity;
                }
            }

            warehouse.ReleaseRequests.Add(request);
            context.Warehouses.Update(warehouse);
            context.SaveChanges();
        }

        private void AddRequestItems(ref TransferRequest request)
        {

            context.WarehouseItem.Load();
            context.TransferRequests.Load();

            var src = context.Warehouses.FirstOrDefault(w => w.Name == textBox1.Text);
            var dest = context.Warehouses.FirstOrDefault(w => w.Name == extraTextBox.Text); 
            if (dataGridView1.RowCount > 1)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("Please provide the Item code");
                        return;
                    }

                    TransferredItem item = new TransferredItem
                    {
                        ItemCode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        TransferRequest = request,
                        WarehouseId = src.WarehouseId
                    };
                    request.Items.Add(item);
                    var srcItem = src.Items.FirstOrDefault(si => si.ItemCode == item.ItemCode);
                    if (srcItem == null)
                    {
                        MessageBox.Show("This item is not available at this warehouse");
                        return;
                    }
                    else
                    {
                        srcItem.Quantity -= item.Quantity;
                        
                    }
                    var destItem = dest.Items.FirstOrDefault(si => si.ItemCode == item.ItemCode);
                    if (destItem == null)
                    {
                        destItem = new WarehouseItem
                        {
                            WarehouseId = dest.WarehouseId,
                            ItemCode = item.ItemCode,
                            Quantity = item.Quantity
                        };
                        dest.Items.Add(destItem);
                    }
                    else
                    {
                        srcItem.Quantity += item.Quantity;
                    }
                }
            }

            context.Warehouses.Update(src);
            context.Warehouses.Update(dest);
            context.SaveChanges();
        }
    }
}
