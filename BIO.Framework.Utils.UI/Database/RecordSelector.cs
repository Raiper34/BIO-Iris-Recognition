using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIO.Framework.Core.Database;

namespace BIO.Framework.Utils.UI.Database {
    public partial class RecordSelector : UserControl {

        private Core.Database.IRecordEnumerable databaseIterator = null;

        public Core.Database.IRecordEnumerable DatabaseIterator {
            get { 
                return databaseIterator; 
            }
            set {
                databaseIterator = value;
                selectedRecord = null;
                this.internalRefresh();
            }
        }

        private Core.Database.Record selectedRecord = null;

        public Core.Database.IRecord SelectedRecord {
            get {
                return selectedRecord;
            }
            set {
                selectedRecord = new Core.Database.Record(value);
                this.internalRefresh();
            }
        }

        bool recursive = false;

        private void internalRefresh() {
            if (this.recursive) return;
            this.recursive = true;
            this.comboBoxBiometricID.Items.Clear();
            
            if (this.databaseIterator != null) {
                foreach (BiometricID bioID in databaseIterator.getBiometricIDs()) {
                    this.comboBoxBiometricID.Items.Add(bioID);
                    if (this.selectedRecord != null && this.selectedRecord.BiometricID.ToString() == bioID.ToString()) {
                        this.comboBoxBiometricID.SelectedItem = bioID; 
                    }
                }
                this.comboBoxBiometricID.Enabled = true;
            } else {
                this.comboBoxBiometricID.Enabled = false;
            }
            this.comboBoxRecordID.Items.Clear();
            if (this.selectedRecord != null) {
                foreach (Core.Database.IRecord r in databaseIterator.getIRecordsByBiometricID(this.selectedRecord.BiometricID)) {
                    this.comboBoxBiometricID.Items.Add(r.SampleID);
                    if (this.selectedRecord != null && this.selectedRecord.SampleID == r.SampleID) {
                        this.comboBoxBiometricID.SelectedItem = r.SampleID.ToString();
                    }
                }
                this.comboBoxRecordID.Enabled = true;
            } else {
                this.comboBoxRecordID.Enabled = false;
            }
            this.recursive = false;
        }

        public RecordSelector() {
            InitializeComponent();
        }

        private void comboBoxBiometricID_SelectedIndexChanged(object sender, EventArgs e) {
            this.updateValues();
        }

        private void updateValues() {
            this.selectedRecord = new Core.Database.Record(
                BIO.Framework.Core.Database.BiometricID.fromString(this.comboBoxBiometricID.SelectedValue.ToString()), 
                this.comboBoxRecordID.SelectedValue.ToString()
            );
            this.internalRefresh();
        }
        
    }
}
