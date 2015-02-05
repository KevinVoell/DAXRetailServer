/*
SAMPLE CODE NOTICE

THIS SAMPLE CODE IS MADE AVAILABLE AS IS.  MICROSOFT MAKES NO WARRANTIES, WHETHER EXPRESS OR IMPLIED, 
OF FITNESS FOR A PARTICULAR PURPOSE, OF ACCURACY OR COMPLETENESS OF RESPONSES, OF RESULTS, OR CONDITIONS OF MERCHANTABILITY.  
THE ENTIRE RISK OF THE USE OR THE RESULTS FROM THE USE OF THIS SAMPLE CODE REMAINS WITH THE USER.  
NO TECHNICAL SUPPORT IS PROVIDED.  YOU MAY NOT DISTRIBUTE THIS CODE UNLESS YOU HAVE A LICENSE AGREEMENT WITH MICROSOFT THAT ALLOWS YOU TO DO SO.
*/

namespace Microsoft.Dynamics.RetailServer.Samples.Extensions
{
    using System.Composition;
    using System.Runtime.InteropServices;

    using Microsoft.Dynamics.Retail.RetailServerLibrary;
    using Microsoft.Dynamics.RetailServer.Samples.Extensions.ODataExtension.NewEntity;

    /// <summary>
    /// The extended EDM model factory.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Edm", Justification = "It is OK.")]
    [Export(typeof(IEdmModelFactory))]
    [ComVisible(false)]
    public class ExtendedEdmModelFactory : CommerceModelFactory
    {
        /// <summary>
        /// Builds actions.
        /// </summary>
        protected override void BuildNonBindableActions()
        {
            base.BuildNonBindableActions();

            var newAction = BindAction("NewAction");
            newAction.Returns<string>();
        }

        /// <summary>
        /// Builds entity sets.
        /// </summary>
        protected override void BuildEntitySets()
        {
            base.BuildEntitySets();

            CommerceModelFactory.BuildEntitySet<ItemSearchEntity>("ItemSearch");
        }
    }
}
