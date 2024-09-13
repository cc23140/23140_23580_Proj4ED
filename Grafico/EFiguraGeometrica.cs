using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    public enum EFiguraGeometrica
    {
        P, L, C, O, E
    }


    public static class ExtensaoEFiguraGeometrica
    {
        public static EFiguraGeometrica RetornarEFiguraGeometrica(char caractere)
        {
            switch (caractere)
            {
                case 'p':
                    return EFiguraGeometrica.P;

                case 'l':
                    return EFiguraGeometrica.L;
                
                 case 'c':
                    return EFiguraGeometrica.C;

                case 'o':
                    return EFiguraGeometrica.O;

                case 'e':
                    return EFiguraGeometrica.E;

                default:
                    throw new ArgumentOutOfRangeException("Caractere da figura geométrica não identificada!");
            }
        }

        public static char RetornarCaractere(EFiguraGeometrica figuraGeometrica)
        {
            switch (figuraGeometrica)
            {
                case EFiguraGeometrica.P:
                    return 'p';

                case EFiguraGeometrica.L:
                    return 'l';

                case EFiguraGeometrica.C:
                    return 'c';

                case EFiguraGeometrica.O:
                    return 'o';

                case EFiguraGeometrica.E:
                    return 'e';

                default:
                    throw new ArgumentOutOfRangeException("Figura geométrica não identificada!");
            }
        }
    }
}
