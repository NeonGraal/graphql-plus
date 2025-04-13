//HintName: Model_output-parent-param.gen.cs
// Generated from output-parent-param.graphql+

/*
*/

namespace GqlTest.Model_output_parent_param;

public interface IOutpPrntParam
{
  FldOutpPrntParam field { get; }
}
public class OutputOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public interface IPrntOutpPrntParam
{
  FldOutpPrntParam field { get; }
}
public class OutputPrntOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public interface IFldOutpPrntParam
{
}
public class DualFldOutpPrntParam
{
}

public interface IInOutpPrntParam
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpPrntParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public interface IPrntOutpPrntParamIn
{
  Number parent { get; }
  String AsString { get; }
}
public class InputPrntOutpPrntParamIn
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
