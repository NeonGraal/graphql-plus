//HintName: Model_output-param-mod-param.gen.cs
// Generated from output-param-mod-param.graphql+

/*
*/

namespace GqlTest.Model_output_param_mod_param;

public interface IOutpParamModParam<Tmod>
{
  DomOutpParamModParam field { get; }
}
public class OutputOutpParamModParam<Tmod>
  : IOutpParamModParam<Tmod>
{
  public DomOutpParamModParam field { get; set; }
}

public interface IInOutpParamModParam
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParamModParam
  : IInOutpParamModParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public interface IDomOutpParamModParam
{
}
public class DomainDomOutpParamModParam
  : IDomOutpParamModParam
{
}
