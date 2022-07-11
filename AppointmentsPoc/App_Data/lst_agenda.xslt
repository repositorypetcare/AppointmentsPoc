<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:util="urn:util"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	exclude-result-prefixes="msxsl">
	<xsl:output method="xml" indent="yes"/>
	<xsl:template match="/root">
		<html>
			<body>
				<center>
					<table class="table table-bordered border-primary">
						<thead>
							<tr>
								<th scope="col">id</th>
								<th scope="col">nome</th>
								<th scope="col">
									<xsl:value-of select="@date1"/>
								</th>
								<th scope="col">
									<xsl:value-of select="@date2"/>
								</th>
								<th scope="col">
									<xsl:value-of select="@date3"/>
								</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="prof">

								<tr>
									<td style="vertical-align: top">
										<xsl:value-of select="@idprof"/>
									</td>
									<td style="vertical-align: top">
										<xsl:value-of select="@nome"/>
									</td>

									<td style="vertical-align: top">
										
											<xsl:for-each select="item[@flag='1']">

												<xsl:value-of select="util:FormatDate(@date)" disable-output-escaping="yes" />
												<br />

											</xsl:for-each>

									</td>

									<td style="vertical-align: top">
											<xsl:for-each select="item[@flag='2']">

												<xsl:value-of select="util:FormatDate(@date)" disable-output-escaping="yes" />
												<br />

											</xsl:for-each>


									</td>
									<td style="vertical-align: top">
											<xsl:for-each select="item[@flag='3']">

												<xsl:value-of select="util:FormatDate(@date)" disable-output-escaping="yes" />
												<br />

											</xsl:for-each>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</center>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>