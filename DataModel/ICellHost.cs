using Formula;

namespace DataModel
{
    public interface ICellHost : IFormulaHost
    {
        Coordinate FindCoordinate(Cell cell);
    }
}
