using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    class Matriz
    {
        const int MAXF = 100;
        const int MAXC = 100;
        private int[,] x;
        private int f, c;


        public Matriz()
        {
            x = new int[MAXF, MAXC];
            f = 0; c = 0;
        }

        public void cargar(int nf, int nc, int a, int b)
        {
            f = nf; c = nc;
            int f1, c1;
            Random r = new Random();
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a, b);
                }
            }
        }
        public string descargar()
        {
            string s = "";
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    s = s + x[f1, c1] + "\x09";
                }
                s = s + "\x0d" + "\x0a";
            }
            return s;
        }
        void intercambiar(int f1, int c1, int f2, int c2)
        {
            int aux = x[f1, c1]; 
            x[f1, c1] = x[f2, c2];
            x[f2,c2]=aux;
        }
        void intercambiarColumna(int c1, int c2)
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                intercambiar(f1, c1, f1, c2);
            }
        }
        public void pregunta1(int fi, int ff, int ci, int cf)
        {
            int i;
            for (int c1 = cf; c1 >= ci; c1--)
            {
                for (int f1 = ff; f1 >= fi; f1--)
                {
                    for (int cd = c1; cd >= ci; cd--)
                    {
                        if (cd == c1)
                        {
                            i = f1;
                        }else{
                            i = ff;
                        }
                        for (int fd = i; fd >= fi; fd--)
                        {
                            if (x[f1, c1] > x[fd, cd])
                            {
                                intercambiar(f1, c1, fd, cd);
                            }
                        }

                    }
                }
            }
        }
         int cpares(int c1)
        {
            int i = 0;
            for (int f1 = 1; f1 <= f; f1++)
            {
                int ele = x[f1, c1];
                if (ele % 2 == 0)
                {
                    i++;
                }
            }
            return i;
        }
         public void ppregunta2()
         {
             for (int c1 = 1; c1 < c; c1++)
             {
                 for (int c2 = c1+1; c2 <= c; c2++)
                 {
                     if (cpares(c1) > cpares(c2))
                     {
                         intercambiarColumna(c1, c2);
                     }
                 }
             }
         }

    }
}
