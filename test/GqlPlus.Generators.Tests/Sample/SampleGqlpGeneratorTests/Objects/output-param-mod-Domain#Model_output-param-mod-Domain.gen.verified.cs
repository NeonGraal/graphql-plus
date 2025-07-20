//HintName: Model_output-param-mod-Domain.gen.cs
// Generated from output-param-mod-Domain.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_param_mod_Domain;

public interface IOutpParamModDmn
{
  DomOutpParamModDmn field { get; }
}
public class OutputOutpParamModDmn
  : IOutpParamModDmn
{
  public DomOutpParamModDmn field { get; set; }
}

public interface IInOutpParamModDmn
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpParamModDmn
  : IInOutpParamModDmn
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public interface IDomOutpParamModDmn
{
}
public class DomainDomOutpParamModDmn
  : IDomOutpParamModDmn
{
}
