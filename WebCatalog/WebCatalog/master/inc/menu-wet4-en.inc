				<script type="text/javascript">
            var y;
				    var secondarymenu = document.getElementById("wb-sec");
				    secondarymenu.innerHTML = wet.builder.secmenu({
				        sections: [{

				            // Rinse and repeat
				            sectionName: "<%=oLang.GetLabel("PublicationsCatalog")%>",
				            sectionLink: "catalog.aspx?l=E",
				            newWindow: false,
				            menuLinks: [{
				                href: "search.aspx?l=E",
				                text: "<%=oLang.GetLabel("Search2")%>"
				            }, {
				                href: "advsearch.aspx?l=E",
				                text: "<%=oLang.GetLabel("AdvTitle")%>"
				            }, {
				                href: "cart.aspx?l=E",
				                text: "<%=oLang.GetLabel("Cart")%>"
				            }, {
				                href: "shipping2.aspx?l=E",
				                text: "<%=oLang.GetLabel("ShippingDetails")%>"
                          }]
                          }]
                          });

                 y = wet.builder.secmenu({
                          sections: [{

                          // Rinse and repeat
                          sectionName: "<%=oLang.GetLabel("PublicationsCatalog")%>",
                          sectionLink: "catalog.aspx?l=E",
                          newWindow: false,
                          menuLinks: [{
                          href: "search.aspx?l=E",
                          text: "<%=oLang.GetLabel("Search2")%>"
                          }, {
                          href: "advsearch.aspx?l=E",
                          text: "<%=oLang.GetLabel("AdvTitle")%>"
                          }, {
                          href: "cart.aspx?l=E",
                          text: "<%=oLang.GetLabel("Cart")%>"
                          }, {
                          href: "shipping2.aspx?l=E",
                          text: "<%=oLang.GetLabel("ShippingDetails")%>"
                          }]
                          }]
                          });
//alert (y);


                        </script>

