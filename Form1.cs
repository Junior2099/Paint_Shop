using System;
using System.Windows.Forms;

namespace app_aula
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpar resultados anteriores
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            try
            {
                // Obter valores de entrada
                double altura = double.Parse(textBox4.Text);
                double comprimento = double.Parse(textBox6.Text);

                // Calcular �rea em metros quadrados
                double area = altura * comprimento;
                textBox5.Text = area.ToString("F2");

                // Adicionar 10% de folga
                double areaComFolga = area * 1.1;

                // Calcular litros necess�rios (1 litro para cada 6m�)
                double litrosNecessarios = areaComFolga / 6;
                textBox7.Text = Math.Ceiling(litrosNecessarios).ToString("F2");

                // Op��o 1: Apenas latas de 18 litros
                if (latas.Checked)
                {
                    int qtdLatas = (int)Math.Ceiling(litrosNecessarios / 18);
                    double precoLatas = qtdLatas * 80.00;

                    textBox1.Text = qtdLatas.ToString();
                    textBox3.Text = precoLatas.ToString("C");
                }

                // Op��o 2: Apenas gal�es de 3.6 litros
                else if (galao.Checked)
                {
                    int qtdGaloes = (int)Math.Ceiling(litrosNecessarios / 3.6);
                    double precoGaloes = qtdGaloes * 25.00;

                    textBox2.Text = qtdGaloes.ToString();
                    textBox3.Text = precoGaloes.ToString("C");
                }

                // Op��o 3: Mistura de latas e gal�es (melhor custo-benef�cio)
                else
                {
                    int qtdLatas = (int)(litrosNecessarios / 18);
                    double litrosRestantes = litrosNecessarios % 18;

                    int qtdGaloes = (int)Math.Ceiling(litrosRestantes / 3.6);

                    // Verificar se compensa mais uma lata extra em vez de v�rios gal�es
                    if (qtdGaloes > 3)
                    {
                        qtdLatas++;
                        qtdGaloes = 0;
                    }

                    double precoTotal = (qtdLatas * 80.00) + (qtdGaloes * 25.00);

                    textBox1.Text = qtdLatas.ToString();
                    textBox2.Text = qtdGaloes.ToString();
                    textBox3.Text = precoTotal.ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular: " + ex.Message);
            }
        }
    }
}