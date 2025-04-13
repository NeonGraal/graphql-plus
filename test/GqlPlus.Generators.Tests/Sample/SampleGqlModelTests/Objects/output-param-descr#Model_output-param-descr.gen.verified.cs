//HintName: Model_output-param-descr.gen.cs
// Generated from output-param-descr.graphql+

/*
*/

namespace GqlTest.Model_output_param_descr;

public interface IOutpParamDescr
{
  FldOutpParamDescr field { get; }
}
public class OutputOutpParamDescr
{
  public FldOutpParamDescr field { get; set; }
}

public interface IFldOutpParamDescr
{
}
public class DualFldOutpParamDescr
{
}

public interface IInOutpParamDescr
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParamDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
