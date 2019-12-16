using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Models
{
    /// <summary>
    /// Request object Equality comparer
    /// </summary>
    public class RequestObjectEqualityComparer : IEqualityComparer<RequestObject>
    {
        /// <summary>
        /// Determines the equality of two request object instances
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(RequestObject x, RequestObject y)
        {
            //if target Api is the same
            if (x.ApiName.Equals(y.ApiName))
            {
                //if target request is the same
                if (x.RequestName.Equals(y.RequestName))
                {
                    //if parameter list length is the same
                    int paramListLength = x.ParameterList.Count;
                    if (x.ParameterList.Count.Equals(y.ParameterList.Count))
                    {
                        //if each parameter is the same
                        for (int ro = 0; ro < paramListLength; ro++)
                        {
                            //determine equality
                            var equal = x.ParameterList.ElementAt(ro).Second.GetHashCode().Equals(y.ParameterList.ElementAt(ro).Second.GetHashCode());

                            //if false break out of loop and return false
                            if(equal is false)
                            {
                                break;
                            }
                            //otherwise continue to go through the parameters
                            else
                            {
                                //if the element number is equal to the length minus 1
                                if (ro.Equals(paramListLength - 1))
                                {
                                    //return true since we have gone through all the parameters and determined they are equal
                                    return true;
                                }
                                
                            }
  
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Default hash function for Request objects for the purposes of comparision
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(RequestObject obj)
        {
            
            int hash = obj.RequestName.GetHashCode() + obj.ApiName.GetHashCode();
            for (int x = 0; x < obj.ParameterList.Count; x++)
            {
                hash += obj.ParameterList.ElementAt(x).First.GetHashCode() + obj.ParameterList.ElementAt(x).Second.GetHashCode();
            }

            return hash;
        }
    }
}
