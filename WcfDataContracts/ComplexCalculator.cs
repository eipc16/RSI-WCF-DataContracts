using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDataContracts
{
    public class ComplexCalculator : IComplexCalculator
    {
        public ComplexNumber add(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real + right.real, left.imaginary + right.imaginary);
        }

        public ComplexNumber div(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(
                (left.real * right.real + left.imaginary * right.imaginary) / (right.real * right.real + right.imaginary * right.imaginary),
                (-left.real * right.imaginary + left.imaginary * right.real) / (right.real * right.real + right.imaginary * right.imaginary));
        }

        public ComplexNumber mult(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(
                (left.real * right.real - left.imaginary * right.imaginary),
                (left.real * right.imaginary + left.imaginary * right.real));
        }

        public ComplexNumber sub(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real - right.real, left.imaginary - right.imaginary);
        }
    }
}
