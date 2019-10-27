namespace ViceCity.Models.Guns.Contracts
{
    public class Rifle : Gun
    {
        private const int BulletsInBarrel = 50;
        private const int TotalBulletsInBarrol = 500;
        public Rifle(string name) 
            : base(name, BulletsInBarrel, TotalBulletsInBarrol)
        {

        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 5 <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= 5;
                this.BulletsPerBarrel = BulletsInBarrel;
                this.TotalBullets -= BulletsInBarrel;
                return 5;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= 5;
                return 5;
            }

            return 0;
        }
    }
}