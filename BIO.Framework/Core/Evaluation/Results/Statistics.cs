using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Core.Evaluation.Results {
    public class Statistics {

        public class StatisticsSettings {
            public double newThresh;
            public bool underThreshAccept;

            public StatisticsSettings(double thresh, bool underThreshaccepted) {
                this.newThresh = thresh;
                this.underThreshAccept = underThreshaccepted;
            }
        }

        public delegate void SettingsChangedEventHandler(StatisticsSettings statisticsSettings);
        //public delegate void ChangedOrientationEventHandler(object sender, EventArgsStatistics);

        public event SettingsChangedEventHandler ThreshChanged;
        public event SettingsChangedEventHandler OrientationChanged;

        public class Extremes {

            bool inited = false;

            public double min = 0.0;
            public double max = 0.0;

            public override string ToString() {
                if (!inited) {
                    return "???";
                }
                return "min:" + String.Format("{0:0.000}", min) + " max:" + String.Format("{0:0.000}", max);
            }

            public void update(double val) {
                if (!inited) {
                    inited = true;
                    min = val;
                    max = val;
                }
                if (val < min) min = val;
                if (val > max) max = val;
            }
        }


        //evaluation object
        Results results = null;

        string method = "";
        public string Method {
            get { return method; }
        }

        private double trueAcceptance = 0.0;

        public double TrueAcceptance {
            get { return trueAcceptance; }
            set { trueAcceptance = value; }
        }
        private double falseAcceptance = 0.0;

        public double FalseAcceptance {
            get { return falseAcceptance; }
            set { falseAcceptance = value; }
        }
        private double trueRejection = 0.0;

        public double TrueRejection {
            get { return trueRejection; }
            set { trueRejection = value; }
        }
        private double falseRejection = 0.0;

        public double FalseRejection {
            get { return falseRejection; }
            set { falseRejection = value; }
        }

        public double FAR {
            get { return this.FalseAcceptance / (this.FalseAcceptance + this.TrueRejection); }
        }
        public double FRR {
            get { return this.FalseRejection / (this.FalseRejection + this.TrueAcceptance); }
        }

        //actual thresh
        private double thresh = 0.0;

        public double Thresh {
            get { return thresh; }
            set {
                if (value != thresh) {
                    thresh = value;
                    this.updateBecauseOfThreshChange();
                    if (ThreshChanged != null) {
                        StatisticsSettings ste = new StatisticsSettings(thresh, this.underThreshAccepted);
                        ThreshChanged(ste);
                    }
                }
            }
        }

        private bool underThreshAccepted = true;

        public bool UnderThreshAccepted {
            get { return underThreshAccepted; }
            set {
                if (value != underThreshAccepted) {
                    underThreshAccepted = value;
                    this.updateBecauseOfThreshChange();
                    if (OrientationChanged != null) {
                        StatisticsSettings ste = new StatisticsSettings(this.thresh, this.underThreshAccepted);
                        OrientationChanged(ste);
                    }
                }
            }
        }

        private Extremes extremes = new Extremes();
        public Extremes GlobalExtremes {
            get { return extremes; }
            set { extremes = value; }
        }

        private Extremes overlapArea = new Extremes();
        public Extremes OverlapAreaExtremes {
            get { return overlapArea; }
            set { overlapArea = value; }
        }

        private Extremes gExtremes = new Extremes();
        public Extremes GenuineExtremes {
            get { return gExtremes; }
            set { gExtremes = value; }
        }
        private Extremes iExtremes = new Extremes();
        public Extremes ImpostorExtremes {
            get { return iExtremes; }
            set { iExtremes = value; }
        }

        double genuinesCount = 0.0;

        public double GenuinesCount {
            get { return genuinesCount; }
            set { genuinesCount = value; }
        }
        double impostorsCount = 0.0;

        public double ImpostorsCount {
            get { return impostorsCount; }
            set { impostorsCount = value; }
        }

        double totalResultsCount = 0.0;

        public double TotalResultsCount {
            get { return totalResultsCount; }
            set { totalResultsCount = value; }
        }


        public Statistics(string method_, Results results_) {
            method = method_;
            results = results_;
            this.updateAll();
            this.autocomputeThresh();
        }

        public void updateAll() {
            //not work yet
            this.updateBecauseOfThreshChange();
        }

        private void innerUpdate(List<Result> resultsList) {
            this.clear(true);
            foreach (Result r in resultsList) {
              
                    //if (results.ActiveFiltering != null && !results.ActiveFiltering.pass(r)) {
                    //    continue;
                    //}
                    MatchingScore cmpValue = r.getMatchingScore(method);
                    
                    if (!cmpValue.IsValid) {
                        continue;
                    }
                    bool isGeniune = r.isGenuine();
                    
                    //Console.Write(isGeniune ? "G" : "I");
                    //Console.Write(cmpValue.ToString());
                    
                    if (isGeniune) {
                        this.GenuinesCount++;
                    } else {
                        this.ImpostorsCount++;
                    }
                    this.TotalResultsCount++;

                    this.GlobalExtremes.update(cmpValue.Score);

                    if (isGeniune) {
                        this.GenuineExtremes.update(cmpValue.Score);
                        if (this.UnderThreshAccepted) {
                            if (cmpValue.Score < this.Thresh) {
                                this.TrueAcceptance++;
                            } else {
                                this.FalseRejection++;
                            }
                        } else {
                            if (cmpValue.Score > this.Thresh) {
                                this.TrueAcceptance++;
                            } else {
                                this.FalseRejection++;
                            }
                        }
                    } else {
                        this.ImpostorExtremes.update(cmpValue.Score);
                        if (this.UnderThreshAccepted) {
                            if (cmpValue.Score < this.Thresh) {
                                this.FalseAcceptance++;
                            } else {
                                this.TrueRejection++;
                            }
                        } else {
                            if (cmpValue.Score > this.Thresh) {
                                this.FalseAcceptance++;
                            } else {
                                this.TrueRejection++;
                            }
                        }
                    }
                
            }

            if (this.underThreshAccepted) {
                this.overlapArea.max = this.GenuineExtremes.max;
                this.overlapArea.min = this.ImpostorExtremes.min;
            } else {
                this.overlapArea.max = this.ImpostorExtremes.max;
                this.overlapArea.min = this.GenuineExtremes.min;
            }
        }

        public void updateBecauseOfThreshChange() {
            this.innerUpdate(results.getResultsList());
            //not work yet


        }

        public void clear(bool all) {
            if (all) {
                this.TotalResultsCount = 0;
                this.ImpostorExtremes = new Extremes();
            }
            this.GlobalExtremes = new Extremes();
            this.GenuineExtremes = new Extremes();
            this.OverlapAreaExtremes = new Extremes();
            this.ImpostorsCount = 0;
            this.GenuinesCount = 0;
            this.FalseAcceptance = 0;
            this.FalseRejection = 0;
            this.TrueAcceptance = 0;
            this.TrueRejection = 0;

        }

        public void autocomputeThresh() {
            if (this.impostorsCount > 0) {
                if (this.ImpostorExtremes.min > this.GlobalExtremes.min) {
                    this.UnderThreshAccepted = true;
                } else {
                    this.UnderThreshAccepted = false;
                }

                if (this.underThreshAccepted) {
                    this.Thresh = this.ImpostorExtremes.min;
                } else {
                    this.Thresh = this.ImpostorExtremes.max;
                }
            }

        }

        public bool isTrueImpostor(double score) {
            return this.underThreshAccepted ? score > thresh : score < thresh;
        }
        public bool isTrueGenuine(double score) {
            return this.underThreshAccepted ? score <= thresh : score >= thresh;
        }

        public Statistics createCopy() {
            Statistics s = new Statistics(this.method, this.results);
            s.underThreshAccepted = this.underThreshAccepted;
            s.thresh = this.thresh;
            return s;
        }
    }
}
