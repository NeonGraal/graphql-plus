//HintName: Gqlp_output-param-type-descr_Intf.gen.cs
// Generated from output-param-type-descr.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param_type_descr;

public interface IOutpParamTypeDescr
{
  FldOutpParamTypeDescr field { get; }
}

public interface IFldOutpParamTypeDescr
{
}

public interface IInOutpParamTypeDescr
{
  Number param { get; }
  String AsString { get; }
}
