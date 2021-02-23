using System;

namespace Polynomials
{
    /// <summary>
    /// 
    ///     A monomial M(x) is a product of powers of the variable x 
    ///     having nonnegative integer exponents and a real coefficient.
    ///     
    ///     This class represents a monomial and has the following:
    ///     
    ///     PROPERTIES
    ///     * coefficient (read-only)
    ///     * exponent (read-only)
    ///     
    ///     METHODS
    ///     * add
    ///     * substract
    ///     * multiply
    ///     * divide
    ///     * evaluate
    ///     
    ///     Notes:
    ///     
    ///     1. To add or sustract two monomial, both must have equal 
    ///        exponents. The result is also a monomial.
    ///     2. To multiply two monomials, there are no restrictions.
    ///        The result is also a monomial.
    ///     3. To divide two monomials, coefficient of divisor must 
    ///        be different than zero, and exponent of dividend must 
    ///        be equal or greater than the exponent of divisor. The
    ///        result is also a monomial.
    /// 
    /// </summary>
    class Monomial
    {
        #region INTERNAL FIELDS

        private readonly double coefficient;
        private readonly int exponent;

        #endregion

        #region CONSTRUCTORS

        // This constructor assumes that M(x) = 0
        public Monomial()
        {
            this.coefficient = 0;
            this.exponent = 0;
        }

        // This constructor receives coefficient and
        // exponent.
        public Monomial(double coefficient, int exponent)
        {
            // Exponent must be a nonnegative integer.
            if (exponent >= 0)
            {
                this.coefficient = coefficient;
                this.exponent = exponent;
            }
            else
            {
                // Throws a runtime error.
                throw new ArgumentException("Exponent must be a nonnegative integer.");
            }
        }

        #endregion

        #region PROPERTIES

        public double Coefficient
        {
            get
            {
                return this.coefficient;
            }
        }

        public int Exponent
        {
            get
            {
                return this.exponent;
            }
        }

        #endregion

        #region METHODS

        public Monomial Add(Monomial monomial)
        {
            // To add monomials, both exponents must be equal.
            if (this.exponent == monomial.exponent)
            {
                return new Monomial(this.coefficient + monomial.coefficient, this.exponent);
            }
            else
            {
                throw new Exception("ADD: Invalid operation.");
            }
        }

        public Monomial Subtract(Monomial monomial)
        {
            // To subtract monomials, both exponents must be equal.
            if (this.exponent == monomial.exponent)
            {
                return new Monomial(this.coefficient - monomial.coefficient, this.exponent);
            }
            else
            {
                throw new Exception("SUBTRACT: Invalid operation.");
            }
        }

        public Monomial Multiply(Monomial monomial)
        {
            return new Monomial(this.coefficient * monomial.coefficient, this.exponent + monomial.exponent);
        }

        public Monomial Divide(Monomial divisor)
        {
            // To divide monomials, coefficient of divisor must be different 
            // than zero and exponent of dividend must be equal or greater than
            // exponent of divisor.
            if (divisor.coefficient != 0 && this.exponent >= divisor.exponent)
            {
                return new Monomial(this.coefficient / divisor.coefficient, this.exponent - divisor.exponent);
            }
            else
            {
                throw new Exception("DIVIDE: Invalid operation.");
            }
        }

        public double Evaluate(double value)
        {
            return this.coefficient * Math.Pow(value, this.exponent);
        }

        override
        public string ToString()
        {
            string result, sign, coefficient, power;

            // String representation of sign is "+" or "-" depending 
            // if coefficient is positive or negative.
            sign = this.coefficient >= 0 ? "+ " : "- ";

            // String representation of coefficient is the absolute
            // value of the coefficient.
            coefficient = Math.Abs(this.coefficient).ToString();

            // If exponent is 0, power is equal to "1";
            // if exponent is 1, string representation of power is "x";
            // if exponent is greater than 1, string representation of
            // power is "x^" followed by exponent value.
            if (this.exponent == 0)
            {
                power = "";
            }
            else if (this.exponent == 1)
            {
                power = " x";
            }
            else
            {
                power = " x^" + this.exponent;
            }

            // SPECIAL CASE: Coefficient is 0, consequently the 
            // monomial is zero.
            if (this.coefficient == 0)
            {
                result = "+ 0";
            }
            else
            {
                result = sign + coefficient + power;
                // "1x" is commonly written as only "x".
                result = result.Replace(" 1 x", " x");
            }

            return result;
        }

        #endregion
    }
}
