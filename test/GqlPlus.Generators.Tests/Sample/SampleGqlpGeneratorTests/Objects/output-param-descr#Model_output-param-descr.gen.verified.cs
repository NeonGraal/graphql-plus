//HintName: Model_output-param-descr.gen.cs
// Generated from output-param-descr.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_param_descr;

public interface IOutpParamDescr
{
  FldOutpParamDescr field { get; }
}
public class OutputOutpParamDescr
  : IOutpParamDescr
{
  public FldOutpParamDescr field { get; set; }
}

public interface IFldOutpParamDescr
{
}
public class DualFldOutpParamDescr
  : IFldOutpParamDescr
{
}

public interface IInOutpParamDescr
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParamDescr
  : IInOutpParamDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
