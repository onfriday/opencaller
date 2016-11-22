namespace OpenCaller.Web.SQLServer.Helpers
{
    //http://danielwertheim.se/sqlgeography-in-sql-server-2012-polygon-must-start-on-correct-position/
    public static class GeographyFactory
    {
        //public static DbGeography CreatePolygon(List<CoordenadaGeograficaValueObject> coordinates, int srid)
        //{
        //    var list = coordinates.Distinct().ToList();

        //    var b = new SqlGeographyBuilder();
        //    b.SetSrid(srid);
        //    b.BeginGeography(OpenGisGeographyType.Polygon);
        //    b.BeginFigure(list[0].Latitude.Value, list[0].Longitude.Value);

        //    for (var i = 1; i < list.Count; i++)
        //        b.AddLine(list[i].Latitude.Value, list[i].Longitude.Value);

        //    b.AddLine(list[0].Latitude.Value, list[0].Longitude.Value);
        //    b.EndFigure();
        //    b.EndGeography();

        //    return DbGeography.FromText((b.ConstructedGeography.EnvelopeAngle() > 90 ? b.ConstructedGeography.ReorientObject() : b.ConstructedGeography).ToString(), srid);
        //}
    }
}
