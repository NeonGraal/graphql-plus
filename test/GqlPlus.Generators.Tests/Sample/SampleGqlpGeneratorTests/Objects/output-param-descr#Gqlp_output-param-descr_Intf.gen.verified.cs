//HintName: Gqlp_output-param-descr_Intf.gen.cs
// Generated from output-param-descr.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param_descr;

public interface IOutpParamDescr
{
  FldOutpParamDescr field { get; }
}

public interface IFldOutpParamDescr
{
}

public interface IInOutpParamDescr
{
  Number param { get; }
  String AsString { get; }
}
