namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsInBarrel = 10;
        private const int TotalBulletsInBarrol = 100;
        public Pistol(string name) 
            : base(name, BulletsInBarrel, TotalBulletsInBarrol)
        {

        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - 1 <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = BulletsInBarrel;
                this.TotalBullets -= BulletsInBarrel;
                return 1;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return 1;
            }

            return 0;
        }

        //The Fire method acts different in all child classes.It shoots bullets and returns the number of bullets that were shot.Here is how it works: 
        //•	Your guns have a barrel, which have a certain capacity for bullets and you shoot a different count of bullets when you pull the trigger. 
        //•	If your barrel becomes empty, you need to reload before you can shoot again.
        //•	Reloading is done by refilling the whole barrel of the gun (Keep in mind, that every barrel has capacity).
        //•	The bullets you take for reloading are taken from the gun's total bullets stock. 
        //    Keep in mind, that every type of gun shoots different count of bullets, when you pull the trigger!

    }
}