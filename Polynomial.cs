using System.Collections.Generic;

namespace Polynomials
{
    /// <summary>
    /// 
    ///     A polynomial P(x) is a sum of monomials of the variable x. 
    ///     
    ///     This class represents a polynomial and has the following:
    ///     
    ///     PROPERTIES
    ///     * coefficients (read-only)
    ///     * exponents (read-only)
    ///     * degree (read-only)
    ///     
    ///     METHODS
    ///     * append
    ///     * add
    ///     * substract
    ///     * multiply
    ///     * evaluate
    ///     
    ///     Notes:
    ///     
    ///     1. This class keeps a simplified collection of monomials,
    ///        sorted from largest to smallest degree.
    ///     2. It has alwyas at least one monomial, even when its value
    ///        is zero.
    /// 
    /// </summary>
    class Polynomial
    {
        #region INTERNAL FIELDS

        private readonly List<Monomial> terms;

        #endregion

        #region CONSTRUCTORS

        public Polynomial()
        {
            // Creates a new empty list
            this.terms = new List<Monomial>();
            // Add the monomial equal to zero
            this.terms.Add(new Monomial());
        }

        #endregion

        #region PROPERTIES

        public List<double> Coefficients
        {
            get
            {
                List<double> coefficients = new List<double>();
                // Traverse the list of monomials extracting
                // their coefficients.
                foreach (Monomial monomial in terms)
                {
                    coefficients.Add(monomial.Coefficient);
                }
                return coefficients;
            }
        }
        public List<int> Exponents
        {
            get
            {
                List<int> exponents = new List<int>();
                // Traverse the list of monomials extracting
                // their exponents.
                foreach (Monomial monomial in terms)
                {
                    exponents.Add(monomial.Exponent);
                }
                return exponents;
            }
        }
        public int Degree
        {
            get
            {
                // It is assumed that list of terms is sorted from 
                // largest to smallest, so the monomial with largest 
                // degree is the first one.
                return this.terms[0].Exponent;
            }
        }

        #endregion

        #region METHODS

        // This method assures that the list of terms is
        // always simplified (cannot exist multiple terms
        // with same degree) and sorted from largest to 
        // smaller degree.
        public void Append(Monomial monomial)
        {
            // The monomial to add must be different than zero.
            if (monomial.Coefficient != 0)
            {
                // If the actual polynomial is zero, internal list
                // only contains one monomial and this monomial will
                // be replaced with the one received.
                if (this.terms.Count == 1 && this.terms[0].Coefficient == 0)
                {
                    this.terms[0] = monomial;
                }
                else
                {
                    bool appended = false;
                    int i = 0;
                    while (!appended && i < this.terms.Count)
                    {
                        // If the exponent of the monomial to append is greater
                        // than the exponent of the monomial [i] analyzed, it 
                        // means that monomial to append does not exists in the
                        // polynomial, so it is inserted in the currente position
                        // to maintain the order of the list.
                        if (monomial.Exponent > this.terms[i].Exponent)
                        {
                            this.terms.Insert(i, monomial);
                            appended = true;
                        }
                        // If the exponent of the monomial to append is equal to
                        // the exponent of the monomial [i] analyzed, perform
                        // addition between monomials and replaces the current
                        // monomial; in the case the sum of the monomials is zero,
                        // removes the current monomial from the list.
                        else if (monomial.Exponent == this.terms[i].Exponent)
                        {
                            if (this.terms[i].Coefficient + monomial.Coefficient != 0)
                            {
                                this.terms[i] = this.terms[i].Add(monomial);
                            }
                            else
                            {
                                this.terms.RemoveAt(i);
                            }
                            appended = true;
                        }
                        // Go to the next monomial in the internal list.
                        else
                        {
                            i++;
                        }
                    }
                    // If monomial has not been appended at this point, append it
                    // at the end of the list.
                    if (!appended)
                    {
                        this.terms.Add(monomial);
                    }
                    // If the list becomes empty, it means that the polynomial is
                    // zero, so append a monomial equal to zero.
                    if (this.terms.Count == 0)
                    {
                        this.terms.Add(new Monomial());
                    }
                    // If the list has only one monomial and its coefficient is 
                    // zero, it means the that polynomial is zero, so replace 
                    // with a monomial equal to zero (this is only for consistency
                    // of monomial representation).
                    else if (this.terms.Count == 1 && this.terms[0].Coefficient == 0)
                    {
                        this.terms[0] = new Monomial();
                    }
                }
            }
        }

        public Polynomial Add(Polynomial polynomial)
        {
            Polynomial sum = new Polynomial();
            // Traverse to add the terms of this polynomial
            foreach(Monomial monomial in terms)
            {
                sum.Append(new Monomial(monomial.Coefficient, monomial.Exponent));
            }
            // Traverse to add the terms of received polyomial
            foreach (Monomial monomial in polynomial.terms)
            {
                sum.Append(new Monomial(monomial.Coefficient, monomial.Exponent));
            }
            return sum;
        }

        public Polynomial Subtract(Polynomial polynomial)
        {
            Polynomial difference = new Polynomial();
            // Traverse to add the terms of this polynomial
            foreach (Monomial monomial in terms)
            {
                difference.Append(new Monomial(monomial.Coefficient, monomial.Exponent));
            }
            // Traverse to add the inverse terms of received polyomial
            foreach (Monomial monomial in polynomial.terms)
            {
                difference.Append(new Monomial(-monomial.Coefficient, monomial.Exponent));
            }
            return difference;
        }

        public Polynomial Multiply(Polynomial polynomial)
        {
            Polynomial product = new Polynomial();
            // Traverse the terms of this polynomial
            foreach (Monomial m1 in terms)
            {
                // Traverse to terms of received polyomial
                foreach (Monomial m2 in polynomial.terms)
                {
                    // Multiply each pair of monomials and
                    // add to product
                    product.Append(m1.Multiply(m2));
                }
            }
            return product;
        }

        // To evaluate the polynomial, sum all values of
        // its internal monomials.
        public double Evaluate(double value)
        {
            double result = 0;
            foreach(Monomial monomial in terms)
            {
                result += monomial.Evaluate(value);
            }
            return result;
        }

        // To convert the polynomial to string, concatenate
        // all string representations of its internal monomials.
        override
        public string ToString()
        {
            string result = "";
            foreach (Monomial monomial in terms)
            {
                result += (" " + monomial.ToString());
            }
            return result.Trim();
        }

        #endregion
    }
}
