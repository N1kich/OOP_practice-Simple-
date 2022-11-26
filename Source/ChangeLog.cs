using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice.Source
{
    public class ChangeLog
    {
        DateTime DateOfChange { get; set; }
        string ChangedField { get; set; }
        string OldData { get; set; }

        IWorkWithClient WhoMadeChanges { get; set; }

        Changetype ChangeType { get; set; }

        public ChangeLog(DateTime DateOfChange, string ChangedField, string oldData, IWorkWithClient WhoMadeChanges, Changetype ChangeType)
        {
            this.DateOfChange = DateOfChange;
            this.ChangedField = ChangedField;
            this.OldData = oldData;
            this.WhoMadeChanges = WhoMadeChanges;
            this.ChangeType = ChangeType;
        }

        public string GetChangeLog()
        {
            return $"ChangeLog info:\n Date of Change client's info: {DateOfChange}\nChanged Property: {ChangedField}\n Old Data: {OldData}\n" +
                $"Who made this Changes: {WhoMadeChanges.GetType().Name}\n" +
                $"Type of changes: {ChangeType.ToString()}\n";
        }
    }
}
