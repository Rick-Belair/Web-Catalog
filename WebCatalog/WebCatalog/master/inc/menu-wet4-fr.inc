				<script type="text/javascript">
				    var secondarymenu = document.getElementById("wb-sec");
				    secondarymenu.innerHTML = wet.builder.secmenu({
				        sections: [{

				            // Rinse and repeat
				            sectionName: "<%=oLang.GetLabel("PublicationsCatalog")%>",
				            sectionLink: "catalog.aspx?l=F",
				            newWindow: false,
				            menuLinks: [{
				                href: "search.aspx?l=F",
				                text: "<%=oLang.GetLabel("Search2")%>"
				            }, {
				                href: "advsearch.aspx?l=F",
				                text: "<%=oLang.GetLabel("AdvTitle")%>"
				            }, {
				                href: "cart.aspx?l=F",
				                text: "<%=oLang.GetLabel("Cart")%>"
				            }, {
				                href: "shipping2.aspx?l=F",
				                text: "<%=oLang.GetLabel("ShippingDetails")%>"
				            }]
				        }]
				    });
				</script>