using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class CronogramaBL
    {
        CronogramaDAC cronogramaDAC = new CronogramaDAC();

        public bool InsertarUsuario(Cronograma cronograma)
        {
            return cronogramaDAC.InsertarCronograma(cronograma);
        }

        public bool ActualizarCronograma(Cronograma cronograma)
        {
            return cronogramaDAC.ActualizarCronograma(cronograma);
        }

        public Cronograma GetCronograma(int id)
        {
            return cronogramaDAC.GetCronograma(id);
        }

        public List<Cronograma> GetCronogramas()
        {
            return cronogramaDAC.GetCronogramas();
        }
    }
}
