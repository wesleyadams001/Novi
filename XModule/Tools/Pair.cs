using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;

namespace XModule.Tools
{

    public class Pair<TFirst> : IEquatable<Pair<TFirst>>, IPair
    {
        public int Degree => 1;

        private TFirst first;

        public Pair(TFirst first)
        {
            this.first = first;
        }

        public TFirst First
        {
            get { return first; }
            set { this.first = value; }
        }

        public bool Equals(Pair<TFirst> other)
        {
            if (other == null)
            {
                return false;
            }
            return EqualityComparer<TFirst>.Default.Equals(this.First, other.First);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TFirst>.Default.GetHashCode(First);
        }
    }

    public class Pair<TFirst, TSecond> : Pair<TFirst>, IEquatable<Pair<TFirst, TSecond>>
    {
        public new int Degree => 2;
        private TSecond second;

        public Pair(TFirst first, TSecond second) : base(first)
        {
            this.second = second;
        }

        public TSecond Second
        {
            get { return second; }
            set { this.second = value; }
        }

        public override bool Equals(object o)
        {
            return Equals(o as Pair<TFirst, TSecond>);
        }


        public bool Equals(Pair<TFirst, TSecond> other)
        {
            if (other == null)
            {
                return false;
            }
            return EqualityComparer<TFirst>.Default.Equals(this.First, other.First) &&
                    EqualityComparer<TSecond>.Default.Equals(this.Second, other.Second);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 37 + EqualityComparer<TFirst>.Default.GetHashCode(First);
        }
    }
}
