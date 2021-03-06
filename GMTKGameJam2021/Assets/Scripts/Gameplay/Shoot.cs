using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class Shoot : MonoBehaviour
    {
        public List<Bullet> storedBullets = new List<Bullet>();
        public Integer currentAmmoCount;
        public Integer maxAmmo;
        

        public int prepAmmo;

        public bool perform;
        // Start is called before the first frame update
        void Start()
        {
            foreach (Bullet storedBullet in storedBullets)
            {
                storedBullet.gameObject.SetActive(false);
            }
            currentAmmoCount.value = storedBullets.Count;
        }

        private void Update()
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                if (!perform)
                {
                    Perform();
                    perform = true;
                }
            }
            else
            {
                perform = false;
            }
        }

        public bool HaveEnoughAmmo()
        {
            return currentAmmoCount.value + prepAmmo >= maxAmmo;
        }

        public bool CollectBullet(Bullet bullet)
        {
            if (storedBullets.Count > maxAmmo || storedBullets.Contains(bullet)) return false;
            storedBullets.Add(bullet);
            bullet.holder = transform;
            bullet.gameObject.SetActive(false);
            currentAmmoCount.value = storedBullets.Count;
            return true;
        }

        public void Perform()
        {
            currentAmmoCount.value = storedBullets.Count;
            if (storedBullets.Count == 0)
            {
                currentAmmoCount.value = storedBullets.Count;
                return;
            }
            Bullet bullet = storedBullets[0];
            storedBullets.Remove(bullet);
            
            ServiceLocator.GetService<IAudioService>().PlaySFX("rock_throw");
            
            Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            bullet.gameObject.SetActive(true);
            bullet.Throw(transform.position, inputDirection);
            currentAmmoCount.value = storedBullets.Count;
        }
    }
}