<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet 
	version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:c="http://tc.belhard.com/2012/Customers">
	
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
				<title>Список клиентов</title>
				<style type="text/css">
					table.customers {border:1px solid navy; border-collapse:collapse}
					table.customers th {border:1px solid navy; background:navy; color:white; padding:5px; text-align:left;}
					table.customers td {border:1px solid navy; padding:5px}
				</style>
			</head>
			<body>
				<table class="customers">
					<tr>
						<th>ID</th>
						<th>Имя компании</th>
						<th>Страна</th>
					</tr>
					<xsl:for-each select="./*/c:Customer">
						<xsl:sort select="c:FullAddress/c:Country"/>
						<xsl:sort select="c:CompanyName" order="descending" />

						<xsl:call-template name="Customer" />
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template name="Customer">
		<tr>
			<td><xsl:value-of select="@CustomerId" /></td>
			<td><xsl:value-of select="c:CompanyName" /></td>
			<td><xsl:value-of select="c:FullAddress/c:Country" /></td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
