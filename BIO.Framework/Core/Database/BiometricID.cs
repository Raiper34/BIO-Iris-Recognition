using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database {
    [Serializable]
    public class BiometricID {
        /// <summary>
        /// person ID (unique person identifier: John Doe)
        /// </summary>
        public string PersonID { get; set; }
        /// <summary>
        /// which biometric is stored (Fingerprint: LeftIndex, Left Iris, Face, ...)
        /// </summary>
        public string Biometric { get; set; }

        public override string ToString() {
            return PersonID + "::" + Biometric;
        }

        public BiometricID() {
            PersonID = "<unknown>";
            Biometric = "<unknown>";
        }
        public BiometricID(string personID, string biometric) {
            PersonID = personID;
            Biometric = biometric;
        }

        public static bool operator ==(BiometricID a, BiometricID b) {
            return a.ToString() == b.ToString();
        }
        public static bool operator !=(BiometricID a, BiometricID b) {
            return !(a == b);
        }
        public override bool Equals(object obj) {
            // If parameter cannot be cast to ThreeDPoint return false:
            BiometricID p = obj as BiometricID;
            if ((object)p == null) {
                return false;
            }

            // Return true if the fields match:
            return this == p;
        }
        public override int GetHashCode() {
            int hc = Biometric.GetHashCode() ^ PersonID.GetHashCode();
            return hc;
        }

        public static BiometricID fromString(string biometricID) {
            string [] parts = biometricID.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            return new BiometricID(parts[0], parts[1]);
        }

       
    }

    class BiometricIDEqualityComparer : IEqualityComparer<BiometricID> {

        public bool Equals(BiometricID b1, BiometricID b2) {
            bool ret = b1 == b2;
            return ret;
        }


        public int GetHashCode(BiometricID bx) {
            int hc = bx.Biometric.GetHashCode() ^ bx.PersonID.GetHashCode();
            return hc;
        }

    }
}
