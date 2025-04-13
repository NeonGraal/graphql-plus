//HintName: Model_output-param.gen.cs
// Generated from output-param.graphql+

/*
*/

namespace GqlTest.Model_output_param;

public interface IOutpParam
{
  FldOutpParam field { get; }
}
public class OutputOutpParam
{
  public FldOutpParam field { get; set; }
}

public interface IFldOutpParam
{
}
public class DualFldOutpParam
{
}

public interface IInOutpParam
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
