using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRP.Domain
{
    public class PaletCount
    {
        public int Total { get; set; }
        public int Rejected { get; set; }
        public int Accepted { get; set; }
        public double Rate { get; set; }

        public PaletCount()
        {
            Total = 0;
            Rejected = 0;
            Accepted = 0;
            Rate = 0;
        }

        public override string ToString()
        {
            return $"Total: {Total} | Accepted: {Accepted} | Rejected: {Rejected} | Rate: {Rate}";
        }

        public PaletCount(int total, int rejected)
        {
            Total = total;
            Rejected = rejected;

            if (Total > Rejected)
                Accepted = Total - Rejected;
            else
                Accepted = 0;

            if (Total > Rejected && Total > 0)
                Rate = (((double)Rejected / Total) * 100);
            else
                Rate = 0.00;
        }

        public void RefreshRate()
        {
            if (Total > 0 && Total > Rejected)
                Rate = (((double)Rejected / Total) * 100);
        }

        public void AddTotal(int toAdd = 1)
        {
            Total = Total + toAdd;
        }

        public void AddRejected(int toAdd = 1)
        {
            Rejected = Rejected + toAdd;
        }

        public void AddAccepted(int toAdd = 1)
        {
            Accepted = Accepted + toAdd;
        }

        public void CountPalet(Palet palet)
        {
            Total++;
            if (palet.State == PaletState.Aceptado)
                Accepted++;
            else
                Rejected++;

            RefreshRate();
        }

        protected bool Equals(PaletCount other)
        {
            return Total == other.Total && Rejected == other.Rejected && Accepted == other.Accepted;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PaletCount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Total;
                hashCode = (hashCode * 397) ^ Rejected;
                hashCode = (hashCode * 397) ^ Accepted;
                return hashCode;
            }
        }
    }
}
