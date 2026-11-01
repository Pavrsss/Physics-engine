using System;
using System.Collections.Generic;
using System.Reflection;

namespace WindowsFormsApp1
{
    public static class CircuitSimulator
    {
        
        public static double GetEffectiveResistance(Form1.BaseElecPiece comp, double appliedVoltage = 0.0)
        {
            if (comp == null) return double.PositiveInfinity;

            Type t = comp.GetType();

            
            MethodInfo mi = t.GetMethod("EffectiveResistanceForVoltage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (mi != null)
            {
                try
                {
                    var result = mi.Invoke(comp, new object[] { appliedVoltage });
                    if (result is double d) return d;
                    if (result != null && double.TryParse(result.ToString(), out d)) return d;
                }
                catch { }
            }

            
            PropertyInfo pf = t.GetProperty("ForwardResistance", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo pr = t.GetProperty("ReverseResistance", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (pf != null && pr != null)
            {
                try
                {
                    double f = Convert.ToDouble(pf.GetValue(comp));
                    double r = Convert.ToDouble(pr.GetValue(comp));
                    return appliedVoltage >= 0 ? f : r;
                }
                catch {  }
            }

            if (string.Equals(t.Name, "Resistor", StringComparison.OrdinalIgnoreCase))
            {
                return Math.Max(0.0, Math.Min(1000.0, comp.Resistance));
            }

            return comp.Resistance;
        }

        public static double ComputeCircuitCurrent(IEnumerable<Form1.BaseElecPiece> components, double additionalOscillatorVoltage = 0.0)
        {
            if (components == null) return 0.0;

            double Vsum = additionalOscillatorVoltage;

            foreach (var c in components)
            {
                if (c is Form1.Ammeter || c is Form1.Voltmeter) continue;
                Vsum += c.Voltage;
            }

            double Rtotal = 0.0;
            foreach (var c in components)
            {
                if (c is Form1.Ammeter || c is Form1.Voltmeter) continue;
                Rtotal += GetEffectiveResistance(c, Vsum);
            }

            if (Rtotal <= 0.0) return 0.0;
            return Vsum / Rtotal;
        }
        public static double ComputeCircuitCurrent(List<Form1.BaseElecPiece> components, double additionalOscillatorVoltage = 0.0)
        {
            return ComputeCircuitCurrent((IEnumerable<Form1.BaseElecPiece>)components, additionalOscillatorVoltage);
        }
    }
}