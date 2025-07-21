//HintName: Gqlp_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_parent_param;

public interface IOutpPrntParam
  : IPrntOutpPrntParam
{
  FldOutpPrntParam field { get; }
}

public interface IPrntOutpPrntParam
{
  FldOutpPrntParam field { get; }
}

public interface IFldOutpPrntParam
{
}

public interface IInOutpPrntParam
{
  Number param { get; }
  String AsString { get; }
}

public interface IPrntOutpPrntParamIn
{
  Number parent { get; }
  String AsString { get; }
}
