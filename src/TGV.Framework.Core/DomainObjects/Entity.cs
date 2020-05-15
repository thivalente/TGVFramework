using System;

namespace TGV.Framework.Core.ValueObject
{
    public abstract class Entity
    {
        #region [ Propriedades ]

        public Guid Id { get; set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={this.Id}]";
        }

        #endregion [ FIM - Metodos ]
    }
}
