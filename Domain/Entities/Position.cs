using Domain.Common;

namespace Domain.Entities
{
    public class Position : BaseEntity
    {
        public bool IsActive { get; private set; }
        public string Name { get; private set; }

        private Position() { }

        private Position(string name)
        {
            SetName(name);
            IsActive = true;
        }

        public static Position Create(string name) 
        { 
            return new Position(name); 
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name can not be empty");

            Name = name.Trim();
        }
    }
}
