﻿// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing force.
    /// </summary>
    public struct Pressure : IComparable, IComparable<Pressure>
    {
        private const double KpaToPaRatio = 1000;
        private const double NscToPaRatio = 0.0001;
        private const double BarToPaRatio = 1E-5;
        private const double TaToPaRatio = 10.197E-6;
        private const double AtmToPaRatio = 9.8692E-6;
        private const double TorrToPaRatio = 7.5006E-3;
        private const double PsiToPaRatio = 145.04E-6;

        /// <summary>
        ///     Pressure in pascal.
        /// </summary>
        public readonly double Pascals;

        public Pressure(double pascals) : this()
        {
            Pascals = pascals;
        }

        #region Unit Properties

        public double KiloPascals
        {
            get { return KpaToPaRatio*Pascals; }
        }

        public double NewtonsPerSquareCentimeter
        {
            get { return NscToPaRatio*Pascals; }
        }

        public double Bars
        {
            get { return BarToPaRatio*Pascals; }
        }

        public double TechnicalAtmosphere
        {
            get { return TaToPaRatio*Pascals; }
        }

        public double Atmosphere
        {
            get { return AtmToPaRatio*Pascals; }
        }

        public double Torr
        {
            get { return TorrToPaRatio*Pascals; }
        }

        public double Psi
        {
            get { return PsiToPaRatio*Pascals; }
        }

        #endregion

        #region Static 

        public static Pressure Zero
        {
            get { return new Pressure(0); }
        }

        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals);
        }

        public static Pressure FromKiloPascals(double kpa)
        {
            return new Pressure(KpaToPaRatio*kpa);
        }

        public static Pressure FromNewtonsPerSquareCentimeter(double nsc)
        {
            return new Pressure(NscToPaRatio*nsc);
        }

        public static Pressure FromBars(double bars)
        {
            return new Pressure(BarToPaRatio*bars);
        }

        public static Pressure FromTechnicalAtmosphere(double ta)
        {
            return new Pressure(TaToPaRatio*ta);
        }

        public static Pressure FromAtmosphere(double atm)
        {
            return new Pressure(AtmToPaRatio*atm);
        }

        public static Pressure FromTorr(double torr)
        {
            return new Pressure(TorrToPaRatio*torr);
        }

        public static Pressure FromPsi(double psi)
        {
            return new Pressure(PsiToPaRatio*psi);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SIPressure to negativize.</param>
        /// <returns></returns>
        public static Pressure operator -(Pressure right)
        {
            return new Pressure(-right.Pascals);
        }

        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals + right.Pascals);
        }

        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals - right.Pascals);
        }

        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left*right.Pascals);
        }

        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left.Pascals/right);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Pressure)) throw new ArgumentException("Expected type Pressure.", "obj");
            return CompareTo((Pressure) obj);
        }

        public int CompareTo(Pressure other)
        {
            return Pascals.CompareTo(other.Pascals);
        }

        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.Pascals <= right.Pascals;
        }

        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.Pascals >= right.Pascals;
        }

        public static bool operator <(Pressure left, Pressure right)
        {
            return left.Pascals < right.Pascals;
        }

        public static bool operator >(Pressure left, Pressure right)
        {
            return left.Pascals > right.Pascals;
        }

        #endregion

        public override string ToString()
        {
            return Pascals + " " + SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.Pascal);
        }
    }
}