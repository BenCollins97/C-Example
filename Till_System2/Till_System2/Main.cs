using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Till_System2
{
    public partial class Main : Form
    {

        Dictionary<int, Button> drinkButtons = new Dictionary<int, Button>();
        Dictionary<int, Button> foodButtons = new Dictionary<int, Button>();
        int drinkButtonCount = 0;
        int foodButtonCount = 0;
        string[] drinkTypes = { "Spirit", "Draught", "Bottle", "Soft" };
        List<Drink> drinkProducts = new List<Drink>();
        List<Food> foodProducts = new List<Food>();
        Sale currentSale = new Sale(0.0m);
        
       


            
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < drinkTypes.Length; i++)
            {
                uiDrinkTypeComboBox.Items.Add(drinkTypes[i]);
                uiDrinkTypeComboBox.SelectedIndex = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            uiPaymentTextBox.Text = "";
        }

        private void addDrink()
        {
            if (drinkButtonCount < 3)
            {
                Button newButton = new Button();
                newButton.Left = 15 + drinkButtonCount * 95;
                newButton.Top = 60;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = drinkProducts[drinkButtonCount].getProduct();
                if (uiDrinkTypeComboBox.Text == drinkTypes[0])
                {
                    newButton.BackColor = Color.Blue;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[1])
                {
                    newButton.BackColor = Color.Green;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[2])
                {
                    newButton.BackColor = Color.Yellow;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[3])
                {
                    newButton.BackColor = Color.Violet;
                }
                newButton.Tag = drinkButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.drinkButton_Click);
                drinkButtons.Add(drinkButtonCount, newButton);
            }
            else if (drinkButtonCount >= 3 && drinkButtonCount < 6)
            {
                Button newButton = new Button();
                newButton.Left = 15 + (drinkButtonCount - 3) * 95;
                newButton.Top = 120;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = drinkProducts[drinkButtonCount].getProduct();
                if (uiDrinkTypeComboBox.Text == drinkTypes[0])
                {
                    newButton.BackColor = Color.Blue;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[1])
                {
                    newButton.BackColor = Color.Green;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[2])
                {
                    newButton.BackColor = Color.Yellow;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[3])
                {
                    newButton.BackColor = Color.Violet;
                }
                newButton.Tag = drinkButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.drinkButton_Click);
                drinkButtons.Add(drinkButtonCount, newButton);
            }
            else if (drinkButtonCount >= 6 && drinkButtonCount < 9)
            {
                Button newButton = new Button();
                newButton.Left = 15 + (drinkButtonCount - 6) * 95;
                newButton.Top = 180;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = drinkProducts[drinkButtonCount].getProduct();
                if (uiDrinkTypeComboBox.Text == drinkTypes[0])
                {
                    newButton.BackColor = Color.Blue;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[1])
                {
                    newButton.BackColor = Color.Green;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[2])
                {
                    newButton.BackColor = Color.Yellow;
                }
                else if (uiDrinkTypeComboBox.Text == drinkTypes[3])
                {
                    newButton.BackColor = Color.Violet;
                }
                newButton.Tag = drinkButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.drinkButton_Click);
                drinkButtons.Add(drinkButtonCount, newButton);
                if (drinkButtonCount >= 9)
                {
                    uiAddDrinkButton.Enabled = false;
                }
            }
           

        }

        private void addFood()
        {
            if (foodButtonCount < 3)
            {
                Button newButton = new Button();
                newButton.Left = 425 + foodButtonCount * 95;
                newButton.Top = 60;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = foodProducts[foodButtonCount].getProduct();
                newButton.BackColor = Color.Red;
                newButton.Tag = foodButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.foodButton_Click);
                foodButtons.Add(foodButtonCount, newButton);
            }
            else if (foodButtonCount >= 3 && foodButtonCount < 6)
            {
                Button newButton = new Button();
                newButton.Left = 425 + (foodButtonCount - 3) * 95;
                newButton.Top = 120;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = foodProducts[foodButtonCount].getProduct();
                newButton.BackColor = Color.Red;
                newButton.Tag = foodButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.foodButton_Click);
                foodButtons.Add(foodButtonCount, newButton);
            }
            else if (foodButtonCount >= 6 && foodButtonCount < 9)
            {
                Button newButton = new Button();
                newButton.Left = 425 + (foodButtonCount - 6) * 95;
                newButton.Top = 180;
                newButton.Width = 90;
                newButton.Height = 40;
                newButton.Text = foodProducts[foodButtonCount].getProduct();
                newButton.BackColor = Color.Red;
                newButton.Tag = foodButtonCount++;
                this.Controls.Add(newButton);
                newButton.Click += new System.EventHandler(this.foodButton_Click);
                foodButtons.Add(foodButtonCount, newButton);
                if (foodButtonCount >= 9)
                {
                    uiAddFoodButton.Enabled = false;
                }
            }
            
        }

        private void uiAddDrinkButton_Click(object sender, EventArgs e)
        {
            if (uiDrinkNameTextBox.Text.Equals("") || uiDrinkPriceTextBox.Equals(""))
            {
                MessageBox.Show("Please fill out required drink information", "Incomplete Information", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    createDrink();
                    addDrink();
                    uiDrinkNameTextBox.Clear();
                    uiDrinkPriceTextBox.Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Please fill out required food information correctly to edit", "Incomplete Information", MessageBoxButtons.OK);
                }
            }

        }

        private void uiAddFoodButton_Click(object sender, EventArgs e)
        {
            if (uiFoodNameTextBox.Text.Equals("") || uiFoodPriceTextBox.Equals(""))
            {
                MessageBox.Show("Please fill out required food information", "Incomplete Information", MessageBoxButtons.OK);
            }
            else
            {
                createFood();
                addFood();
                uiFoodNameTextBox.Clear();
                uiFoodPriceTextBox.Clear();
            }
        }

        private void drinkButton_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            int currentDrink = (int)b.Tag;

            if (uiEditDrinkCheckBox.Checked)
            {
                try
                {
                    drinkProducts[currentDrink].setPrice(decimal.Parse(uiDrinkPriceTextBox.Text));
                    drinkProducts[currentDrink].setProduct(uiDrinkNameTextBox.Text);                   
                    drinkProducts[currentDrink].setType(uiDrinkTypeComboBox.Text);
                    if (uiDrinkTypeComboBox.Text == drinkTypes[0])
                    {
                        b.BackColor = Color.Blue;
                    }
                    else if (uiDrinkTypeComboBox.Text == drinkTypes[1])
                    {
                        b.BackColor = Color.Green;
                    }
                    else if (uiDrinkTypeComboBox.Text == drinkTypes[2])
                    {
                        b.BackColor = Color.Yellow;
                    }
                    else if (uiDrinkTypeComboBox.Text == drinkTypes[3])
                    {
                        b.BackColor = Color.Violet;
                    }
                    b.Text = drinkProducts[currentDrink].getProduct();
                    uiDrinkNameTextBox.Clear();
                    uiDrinkPriceTextBox.Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Please fill out required drink information correctly to edit", "Incomplete Information", MessageBoxButtons.OK);
                }
            }
            else
            {
                
                
                uiSaleListBox.Items.Add(drinkProducts[currentDrink].getProduct() + "  £" + drinkProducts[currentDrink].getPrice().ToString());
                currentSale.increaseCurrentPrice(drinkProducts[currentDrink].getPrice());
                uiTotalCostLabel.Text = "Total Cost £" + currentSale.getCurrentPrice();
                uiSaleListBox.SelectedIndex = uiSaleListBox.Items.Count - 1;
                currentSale.setLastPrice(drinkProducts[currentDrink].getPrice());
                currentSale.addPrices();
            }
            

            
        }

        private void foodButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int currentFood = (int)b.Tag;

            if (uiEditFoodCheckBox.Checked)
            {
                try
                {
                    foodProducts[currentFood].setPrice(decimal.Parse(uiFoodPriceTextBox.Text));
                    foodProducts[currentFood].setProduct(uiFoodNameTextBox.Text);
                    b.Text = foodProducts[currentFood].getProduct();
                    uiFoodNameTextBox.Clear();
                    uiFoodPriceTextBox.Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Please fill out required food information correctly to edit", "Incomplete Information", MessageBoxButtons.OK);
                }
            }
            else
            {
              
                uiSaleListBox.Items.Add(foodProducts[currentFood].getProduct() + "  £" + foodProducts[currentFood].getPrice().ToString());
                currentSale.increaseCurrentPrice(foodProducts[currentFood].getPrice());
                uiTotalCostLabel.Text = "Total Cost £" + currentSale.getCurrentPrice();
                uiSaleListBox.SelectedIndex = uiSaleListBox.Items.Count - 1;
                currentSale.setLastPrice(foodProducts[currentFood].getPrice());
                currentSale.addPrices();
               
            }
        }

        private void createDrink()
        {

            
                Drink newDrink = new Drink(uiDrinkNameTextBox.Text, decimal.Parse(uiDrinkPriceTextBox.Text), uiDrinkTypeComboBox.Text);
                drinkProducts.Add(newDrink);

        }

        private void createFood()
        {
            try
            {
                Food newFood = new Food(uiFoodNameTextBox.Text, decimal.Parse(uiFoodPriceTextBox.Text));
                foodProducts.Add(newFood);
            }
            catch (Exception)
            {
                MessageBox.Show("Price can only be a number", "Error", MessageBoxButtons.OK);
            }

        }
        private void payPadButton_Click(object sender, EventArgs e)
        {
            if (uiPaymentTextBox.Text == "0")
            {
                uiPaymentTextBox.Clear();
            }
            Button b = (Button)sender;
            uiPaymentTextBox.Text = uiPaymentTextBox.Text + b.Text;

        }

        private void uiCashButton_Click(object sender, EventArgs e)
        {
            if (currentSale.getCurrentPrice() > 0)
            {
                if (uiPaymentTextBox.Text != "0")
                {
                    decimal amountPayed = decimal.Parse(uiPaymentTextBox.Text);
                    currentSale.decreaseCurrentPrice(amountPayed);
                    if (currentSale.getCurrentPrice() <= 0.0m)
                    {
                        MessageBox.Show("Change is £" + currentSale.getCurrentPrice(), "Change", MessageBoxButtons.OK);
                        currentSale.resetCurrentPrice();
                        uiPaymentTextBox.Text = "0";
                        uiTotalCostLabel.Text = "Total Cost £" + currentSale.getCurrentPrice();
                        uiSaleListBox.Items.Clear();
                        currentSale.clearAllPrices();
                    }
                    else
                    {
                        uiTotalCostLabel.Text = " Total Cost £" + currentSale.getCurrentPrice();
                        uiPaymentTextBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter amount to be payed", "Enter Amount", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("There is no items in current sale", "Change", MessageBoxButtons.OK);
                uiPaymentTextBox.Clear();
            }
        }

        private void uiCardButton_Click(object sender, EventArgs e)
        {
            if (currentSale.getCurrentPrice() > 0)
            {
                currentSale.resetCurrentPrice();
                MessageBox.Show("Card transaction has been successfully processed", "Card Transaction", MessageBoxButtons.OK);
                uiTotalCostLabel.Text = " Total Cost £" + currentSale.getCurrentPrice();
                uiSaleListBox.Items.Clear();
                currentSale.clearAllPrices();
            }
            else
            {
                MessageBox.Show("There is no items in current sale", "Change", MessageBoxButtons.OK);
            }
        }

        private void uiErrorCorrectionButton_Click(object sender, EventArgs e)
        {
            if (uiSaleListBox.Items.Count == 0)
            {
                MessageBox.Show("No items in sale", "Sale", MessageBoxButtons.OK);
            }
            else
            {
                uiSaleListBox.Items.RemoveAt(uiSaleListBox.SelectedIndex);
                currentSale.decreaseCurrentPrice(currentSale.getLastPrice());
                currentSale.removePrice();
                uiTotalCostLabel.Text = uiTotalCostLabel.Text = " Total Cost £" + currentSale.getCurrentPrice();
                uiSaleListBox.SelectedIndex = uiSaleListBox.Items.Count - 1;
            }
            

        }

        private void uiEditDrinkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (uiEditDrinkCheckBox.Checked)
            {
                uiEditDrinkCheckBox.BackColor = Color.Red;
                MessageBox.Show("You are now in edit mode. To edit a drink product fill out the required information and then click on the drink you would like to edit", "Drink Edit Mode", MessageBoxButtons.OK);
            }
            else
            {
                uiEditDrinkCheckBox.BackColor = Color.White;
            }
        }

        private void uiEditFoodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (uiEditFoodCheckBox.Checked)
            {
                uiEditFoodCheckBox.BackColor = Color.Red;
                MessageBox.Show("You are now in edit mode. To edit a food product fill out the required information and then click on the food you would like to edit", "Food Edit Mode", MessageBoxButtons.OK);
            }
            else
            {
                uiEditFoodCheckBox.BackColor = Color.White;
            }
        }

        private void uiDrinkPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch !=8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void uiFoodPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
