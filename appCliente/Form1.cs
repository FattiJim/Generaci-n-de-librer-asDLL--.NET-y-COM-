using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassroomWS_cliente;
using System.Web.Services.Protocols;

//COM: "%WINDIR%\Microsoft.Net\Framework\v4.0.30319\regasm.exe" ClassroomWS_cliente.dll /tlb /nologo /codebase

namespace appCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassroomWS cliente = new ClassroomWS();
            //servicio_alumno.RespuestaEvaluarAlumno res = cliente.EvaluarAlumno("pruebas", "12345678a", "201938614", 8);
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                try
                {
                    int semestre = int.Parse(textBox4.Text);
                    //código que realiza la llamada al método.
                    if (cliente.validacion(semestre) == false)
                    {
                        MessageBox.Show("El semestre debe ser mayor a 0");
                    }
                    else
                    {
                        RespuestaEvaluarAlumno res = cliente.EvaluarAlumno(textBox1.Text, textBox2.Text, textBox3.Text, semestre);
                        textBox5.Text = "Codigo: " + res.code + "\r\n" +
                            "Mensaje: " + res.message + "\r\n" +
                            "Datos: " + res.data + "\r\n" +
                            "Promedio: " + res.promedio + "\r\n" +
                            "Estatus: " + res.status + "\r\n";

                    }
                }
                catch (SoapException ex)
                {
                    // Excepción SOAP-Fault cachada
                    textBox5.Text = "Codigo: " + ex.Code.ToString() + "\r\n" +
                        "Mensaje: " + ex.Message.ToString();

                }
            } else
            {
                MessageBox.Show("Ingresa el numero de semestre o Falta algun dato por colocar");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassroomWS cliente2 = new ClassroomWS();
            if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" )
            {
                try
                {
                    RespuestaBienvenida res2 = cliente2.Bienvenida(textBox6.Text, textBox7.Text, textBox8.Text);

                    textBox9.Text = "Codigo: " + res2.code + "\r\n" +
                        "Mensaje: " + res2.message + "\r\n" +
                        "Estatus: " + res2.status + "\r\n";
                }
                catch (SoapException ex)
                {
                    // Excepción SOAP-Fault cachada
                    textBox9.Text = "Codigo: " + ex.Code.ToString() + "\r\n" +
                        "Mensaje: " + ex.Message.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ingresalos datos");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassroomWS cliente3 = new ClassroomWS();
            if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
            {
                try
                {
                    RespuestaBienvenida res3 = cliente3.Bienvenida(textBox10.Text, textBox11.Text, textBox12.Text);

                    textBox13.Text = "Codigo: " + res3.code + "\r\n" +
                        "Mensaje: " + res3.message + "\r\n" +
                        "Estatus: " + res3.status + "\r\n";
                }
                catch (SoapException ex)
                {
                    // Excepción SOAP-Fault cachada
                    textBox13.Text = "Codigo: " + ex.Code.ToString() + "\r\n" +
                        "Mensaje: " + ex.Message.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ingresa los datos");
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
    }
}
