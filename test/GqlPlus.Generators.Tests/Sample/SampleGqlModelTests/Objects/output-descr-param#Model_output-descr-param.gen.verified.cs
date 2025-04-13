//HintName: Model_output-descr-param.gen.cs
// Generated from output-descr-param.graphql+

/*
*/

namespace GqlTest.Model_output_descr_param;

public interface IOutpDescrParam
{
  FldOutpDescrParam field { get; }
}
public class OutputOutpDescrParam
{
  public FldOutpDescrParam field { get; set; }
}

public interface IFldOutpDescrParam
{
}
public class DualFldOutpDescrParam
{
}

public interface IInOutpDescrParam
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpDescrParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
