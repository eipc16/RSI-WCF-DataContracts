using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDataContracts
{
    [ServiceContract]
    public interface IComplexCalculator
    {
        [OperationContract]
        ComplexNumber add(ComplexNumber left, ComplexNumber right);

        [OperationContract]
        ComplexNumber sub(ComplexNumber left, ComplexNumber right);

        [OperationContract]
        ComplexNumber mult(ComplexNumber left, ComplexNumber right);

        [OperationContract]
        ComplexNumber div(ComplexNumber left, ComplexNumber right);
    }

    [DataContract]
    public class ComplexNumber
    {
        [DataMember]
        public double real;

        [DataMember]
        public double imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
    }
}
