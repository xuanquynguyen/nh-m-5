using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class ClPrintBill
    {
		private DbBill _dbBill = null;
		public PrintDialog prnDialog = null;
		public PrintPreviewDialog prnPreview = null;
		public PrintDocument prnDocument = null;

		public string InvTitle = "";
		public string Address = "";
		public string PhoneNumber = "";
		public string TaxCode = "";
		public string InvImage = "";

		public int CurrentY = 0;
		public int CurrentX = 0;
		public int leftMargin = 0;
		public int rightMargin = 0;
		public int topMargin = 0;
		public int bottomMargin = 0;
		public int InvoiceWidth = 0;
		public int InvoiceHeight = 0;
		public string _tableOrName = "";
		public string _customerCity = "";
		public string _employeesName = "";

		public DateTime _dateBill = DateTime.Now;

		public decimal InvoiceTotal = 0;
		public bool ReadInvoice = false;
		public int AmountPosition = 0;

		public DataTable _dt = null;
		public long _idBill = 0;

		public Font InvTitleFont = new Font("Arial", 24, FontStyle.Regular);
		public int InvTitleHeight;
		public Font InvSubTitleFont = new Font("Arial", 14, FontStyle.Regular);
		public int InvSubTitleHeight;
		public Font InvoiceFont = new Font("Arial", 12, FontStyle.Regular);
		public int InvoiceFontHeight;
		public SolidBrush BlueBrush = new SolidBrush(Color.Blue);
		public SolidBrush RedBrush = new SolidBrush(Color.Red);
		public SolidBrush BlackBrush = new SolidBrush(Color.Black);
		public ClPrintBill(long idbill, string employees, string table, string address)
		{
			_tableOrName = table;
			_employeesName = employees;
			_customerCity = address;
			_idBill = idbill;
			this.prnDialog = new PrintDialog();
			this.prnPreview = new PrintPreviewDialog();
			this.prnDocument = new PrintDocument();
			prnDocument.PrintPage += new PrintPageEventHandler(prnDocument_PrintPage);
			_dbBill = new DbBill();
		}

		public void prnDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			leftMargin = (int)e.MarginBounds.Left + 40;
			rightMargin = (int)e.MarginBounds.Right - 40;
			topMargin = (int)e.MarginBounds.Top;
			bottomMargin = (int)e.MarginBounds.Bottom;
			InvoiceWidth = (int)e.MarginBounds.Width;
			InvoiceHeight = (int)e.MarginBounds.Height;

			if (!ReadInvoice)
				ReadInvoiceData();

			SetInvoiceHead(e.Graphics);
			SetOrderData(e.Graphics);
			SetInvoiceData(e.Graphics, e);

			ReadInvoice = true;
		}

		public void ReadInvoiceData()
		{
			_dt = new DataTable();
			_dt = _dbBill.PrintBil(_idBill);
		}

		public void SetInvoiceHead(Graphics g)
		{
			ReadInvoiceHead();

			CurrentY = topMargin;
			CurrentX = leftMargin;
			int ImageHeight = 0;

			if (System.IO.File.Exists(InvImage))
			{
				Bitmap oInvImage = new Bitmap(InvImage);
				int xImage = CurrentX + (InvoiceWidth - oInvImage.Width) / 2;
				ImageHeight = oInvImage.Height;
				g.DrawImage(oInvImage, xImage, CurrentY);
			}

			InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
			InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

			int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
			int lenInvSubTitle1 = (int)g.MeasureString(Address, InvSubTitleFont).Width;
			int lenInvSubTitle2 = (int)g.MeasureString(PhoneNumber, InvSubTitleFont).Width;
			int lenInvSubTitle3 = (int)g.MeasureString(TaxCode, InvSubTitleFont).Width;
			int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
			int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
			int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
			int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

			if (InvTitle != "")
			{
				CurrentY = CurrentY + ImageHeight;
				g.DrawString(InvTitle, InvTitleFont, BlueBrush, xInvTitle, CurrentY);
			}
			if (Address != "")
			{
				CurrentY = CurrentY + InvTitleHeight;
				g.DrawString(Address, InvSubTitleFont, BlueBrush, xInvSubTitle1, CurrentY);
			}
			if (PhoneNumber != "")
			{
				CurrentY = CurrentY + InvSubTitleHeight;
				g.DrawString(PhoneNumber, InvSubTitleFont, BlueBrush, xInvSubTitle2, CurrentY);
			}
			if (TaxCode != "")
			{
				CurrentY = CurrentY + InvSubTitleHeight;
				g.DrawString(TaxCode, InvSubTitleFont, BlueBrush, xInvSubTitle3, CurrentY);
			}

			CurrentY = CurrentY + InvSubTitleHeight + 8;
			g.DrawLine(new Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY);
		}

		public void SetOrderData(Graphics g)
		{
			string FieldValue = "";
			InvoiceFontHeight = (int)(InvoiceFont.GetHeight(g));
			CurrentX = leftMargin;
			CurrentY = CurrentY + 8;
			FieldValue = SHOW_TABLE_CUS + _tableOrName;
			g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
			CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
			FieldValue = SHOW_ADDRESS + _customerCity;
			g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
			CurrentX = leftMargin;
			CurrentY = CurrentY + InvoiceFontHeight;
			FieldValue = SHOW_EMPLOYEES + _employeesName;
			g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
			CurrentX = leftMargin;
			CurrentY = CurrentY + InvoiceFontHeight;
			FieldValue = SHOW_BILL_CODE + _idBill;
			g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);
			CurrentX = CurrentX + (int)g.MeasureString(FieldValue, InvoiceFont).Width + 16;
			FieldValue = SHOW_DAY + _dateBill;
			g.DrawString(FieldValue, InvoiceFont, BlackBrush, CurrentX, CurrentY);

			CurrentY = CurrentY + InvoiceFontHeight + 8;
			g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
		}

		public void SetInvoiceData(Graphics g, PrintPageEventArgs e)
		{
			string FieldValue = "";
			int CurrentRecord = 0;
			int RecordsPerPage = 20;
			decimal Amount = 0;

			int xProductName = leftMargin;
			CurrentY = CurrentY + InvoiceFontHeight;

			g.DrawString(SHOW_PRODUCT_NAME, InvoiceFont, BlueBrush, xProductName, CurrentY);

			int xUnitPrice = xProductName + (int)g.MeasureString("Product Name", InvoiceFont).Width + 72;
			g.DrawString(SHOW_UNIT_PRICE, InvoiceFont, BlueBrush, xUnitPrice, CurrentY);

			int xQuantity = xUnitPrice + (int)g.MeasureString("Unit Price", InvoiceFont).Width + 4;
			g.DrawString(SHOW_NUMBER, InvoiceFont, BlueBrush, xQuantity, CurrentY);

			AmountPosition = xQuantity + (int)g.MeasureString("Discount", InvoiceFont).Width + 8;
			g.DrawString(SHOW_INTO_MONEY, InvoiceFont, BlueBrush, AmountPosition, CurrentY);
			CurrentY = CurrentY + InvoiceFontHeight + 8;

			foreach (DataRow row in _dt.Rows)
			{
				FieldValue = row["ProductName"].ToString();
				if (FieldValue.Length > 20)
                {
					FieldValue = FieldValue.Remove(20, FieldValue.Length - 20);
				}					
				
				g.DrawString(FieldValue, InvoiceFont, BlackBrush, xProductName, CurrentY);
				FieldValue = String.Format("{0:#,##0}", row["unitPrice"]);
				g.DrawString(FieldValue, InvoiceFont, BlackBrush, xUnitPrice, CurrentY);
				FieldValue = row["quantity"].ToString();
				g.DrawString(FieldValue, InvoiceFont, BlackBrush, xQuantity, CurrentY);
				Amount = Convert.ToDecimal(row["intoMoney"]);
				FieldValue = String.Format("{0:#,##0}", Amount);
				int xAmount = AmountPosition + (int)g.MeasureString("intoMoney", InvoiceFont).Width;
				xAmount = xAmount - (int)g.MeasureString(FieldValue, InvoiceFont).Width;
				g.DrawString(FieldValue, InvoiceFont, BlackBrush, xAmount, CurrentY);
				CurrentY = CurrentY + InvoiceFontHeight;

				_tableOrName = row["nameTb"] == null ? "" : (string)row["nameTb"];
				string more = Common.GetDbNull1<string>(row, "name");
				_tableOrName += more;
				_employeesName = Common.GetDbNull1<string>(row, "fullName");
				_dateBill = (DateTime)row["billDate"];
				_customerCity = Common.GetDbNull1<string>(row, "phone");
				InvoiceTotal += Amount;
				CurrentRecord++;
			}

			if (CurrentRecord < RecordsPerPage)
				e.HasMorePages = false;
			else
				e.HasMorePages = true;

			SetInvoiceTotal(g);
			g.Dispose();
		}

		public void SetInvoiceTotal(Graphics g)
		{
			CurrentY = CurrentY + 8;
			g.DrawLine(new Pen(Brushes.Black), leftMargin, CurrentY, rightMargin, CurrentY);
			int xRightEdg = AmountPosition + (int)g.MeasureString("intoMoney", InvoiceFont).Width;
			int xInvoiceTotal = AmountPosition - (int)g.MeasureString(SHOW_TOTAL_MONEY, InvoiceFont).Width;
			CurrentY = CurrentY + InvoiceFontHeight;
			g.DrawString(SHOW_TOTAL_MONEY, InvoiceFont, RedBrush, xInvoiceTotal, CurrentY);
			string InvoiceValue = String.Format("{0:#,##0}", InvoiceTotal);
			int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
			g.DrawString(InvoiceValue, InvoiceFont, BlackBrush, xInvoiceValue, CurrentY);
		}

		public void DisplayDialog()
		{
			try
			{
				prnDialog.Document = this.prnDocument;
				DialogResult ButtonPressed = prnDialog.ShowDialog();
				if (ButtonPressed == DialogResult.OK)
					prnDocument.Print();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public void DisplayInvoice()
		{
			prnPreview.Document = this.prnDocument;

			try
			{
				prnPreview.ShowDialog();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public void ReadInvoiceHead()
		{
			DataTable dt = DbStore.GetInfoStore();
			DataRow dr = dt.Rows[0];

			InvTitle = (string)dr["nameStore"];
			Address = SHOW_ADDRESS + (string)dr["addressStore"];
			PhoneNumber = SHOW_PHONE_NUMBER + (string)dr["phoneStore"];
			TaxCode = SHOW_TAX_CODE + (string)dr["taxCode"];
			InvImage = Application.StartupPath + @"\Images\" + "InvPic.jpg";
		}

		public void PrintReport()
		{
			try
			{
				prnDocument.Print();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public void btnPrint_Click(object sender, EventArgs e)
		{
			ReadInvoice = false;
			PrintReport();
		}

		public void btnPreview_Click(object sender, EventArgs e)
		{
			ReadInvoice = false;
			DisplayInvoice();
		}

		public void btnDialog_Click(object sender, EventArgs e)
		{
			ReadInvoice = false;
			DisplayDialog();
		}
	}
}
