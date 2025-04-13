//HintName: Model_output-param-type-descr.gen.cs
// Generated from output-param-type-descr.graphql+

/*
*/

namespace GqlTest.Model_output_param_type_descr;

public interface IOutpParamTypeDescr
{
  FldOutpParamTypeDescr field { get; }
}
public class OutputOutpParamTypeDescr
{
  public FldOutpParamTypeDescr field { get; set; }
}

public interface IFldOutpParamTypeDescr
{
}
public class DualFldOutpParamTypeDescr
{
}

public interface IInOutpParamTypeDescr
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParamTypeDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
