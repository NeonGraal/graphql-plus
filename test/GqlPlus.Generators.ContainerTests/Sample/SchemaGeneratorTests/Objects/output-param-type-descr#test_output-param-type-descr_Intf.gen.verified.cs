//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  ItestOutpParamTypeDescrObject AsOutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
{
  ItestFldOutpParamTypeDescr Field (ItestInOutpParamTypeDescr parameter);
}

public interface ItestFldOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamTypeDescrObject AsFldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
{
}

public interface ItestInOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestInOutpParamTypeDescrObject AsInOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
{
  decimal Param { get; }
}
