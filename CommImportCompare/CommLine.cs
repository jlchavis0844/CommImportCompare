
namespace CommImportCompare {
   public class CommLine {
        public string Policy { get; set; }
        public string Name { get; set; }
        public string Premium { get; set; }
        public double Total { get; set; }
        public string Key { get; set; }

        public CommLine(string Policy, string Name, string Premium, double Total) {
            this.Policy = Policy;
            this.Name = Name;
            this.Premium = Premium;
            this.Total = Total;
            Key = Policy + Premium + Total.ToString();
        }
        public override string ToString() {
            return (Key + "\t" + Name + "\t" + Policy + "\t" + Premium + "\t" + Total).ToString();
        }
    }
}
