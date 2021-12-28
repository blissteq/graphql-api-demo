namespace ZA365Solutions.Platform.Common
{
    using System;

    public class BaseEntity : IEntity
    {
        private Guid _id;
        protected bool _isDeleted;
        protected bool _isNew;

        public BaseEntity()
        {
        }

        protected BaseEntity(Guid id, bool isDeleted)
        {
            this._id = id;
            this._isDeleted = isDeleted;
        }

        public Guid Id
        {
            get => this._id;
            set => this._id = value;
        }

        public bool IsDeleted
        {
            get => this._isDeleted;
            set => this._isDeleted = value;
        }

        public bool IsNew
        {
            get => this._isNew;
            set => this._isNew = value;
        }

        public void Delete() => this._isDeleted = true;

        public void MakeNew() => this._isNew = true;
    }
}

