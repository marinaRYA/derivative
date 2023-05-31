using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derivative
{
    public class CubicSpline
    {
        SplineTuple[] splines; // Сплайн

        // Структура, описывающая сплайн на каждом сегменте сетки
        private struct SplineTuple
        {
            public float a, b, c, d, x;
        }
        public void BuildSpline(float[] x, float[] y, int n)
        {
            // Инициализация массива сплайнов
            splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = x[i];
                splines[i].a = y[i];
            }
            splines[0].c = splines[n - 1].c = 0;

            // Решение СЛАУ относительно коэффициентов сплайнов c[i] методом прогонки для трехдиагональных матриц
            // Вычисление прогоночных коэффициентов - прямой ход метода прогонки
            float[] alpha = new float[n - 1];
            float[] beta = new float[n - 1];
            alpha[0] = beta[0] = 0;
            for (int i = 1; i < n - 1; ++i)
            {
                float hi = x[i] - x[i - 1];
                float hi1 = x[i + 1] - x[i];
                float A = hi;
                float C = 2 * (hi + hi1);
                float B = hi1;
                float F = 6 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                float z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            // Нахождение решения - обратный ход метода прогонки
            for (int i = n - 2; i > 0; --i)
            {
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
            }

            // По известным коэффициентам c[i] находим значения b[i] и d[i]
            for (int i = n - 1; i > 0; --i)
            {
                float hi = x[i] - x[i - 1];
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2 * splines[i].c + splines[i - 1].c) / 6 + (y[i] - y[i - 1]) / hi;
            }
        }

        // Вычисление значения интерполированной функции в произвольной точке
        public float Interpolate(float x)
        {
            if (splines == null)
            {
                return float.NaN; // Если сплайны ещё не построены - возвращаем NaN
            }

            int n = splines.Length;
            SplineTuple s;

            if (x <= splines[0].x) // Если x меньше точки сетки x[0] - пользуемся первым эл-тов массива
            {
                s = splines[0];
            }
            else if (x >= splines[n - 1].x) // Если x больше точки сетки x[n - 1] - пользуемся последним эл-том массива
            {
                s = splines[n - 1];
            }
            else // Иначе x лежит между граничными точками сетки - производим бинарный поиск нужного эл-та массива
            {
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= splines[k].x)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }
                s = splines[j];
            }

            float dx = x - s.x;
            return s.a + (s.b + (s.c / 2 + s.d * dx / 6) * dx) * dx;
        }

    }
    public class Data
    {
        public float[] x;
        public float[] y;
        public Data() { x = new float[5]; y = new float[5]; }
        public void x_enter(int i, float a) { x[i] = a; }
        public void y_enter(int i, float a) { y[i] = a; }
        public float x_ret(int i) { return x[i]; }
        public float y_ret(int i) { return y[i]; }

    }
    internal static class Program
    {
      
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
