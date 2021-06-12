using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Shoot : MonoBehaviour
    {
        public List<Bullet> storedBullets = new List<Bullet>();
        public Integer currentAmmoCount;
        public Integer maxAmmo;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Perform();
            }
        }

        public bool CollectBullet(Bullet bullet)
        {
            if (storedBullets.Count > maxAmmo || storedBullets.Contains(bullet)) return false;

            storedBullets.Add(bullet);
            bullet.gameObject.SetActive(false);
            currentAmmoCount.value = storedBullets.Count;
            return true;
        }

        public void Perform()
        {
            if (storedBullets.Count == 0) return;
            Bullet bullet = storedBullets[0];
            storedBullets.Remove(bullet);
            Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            bullet.gameObject.SetActive(true);
            bullet.Throw(transform.position, inputDirection);
        }
    }
}