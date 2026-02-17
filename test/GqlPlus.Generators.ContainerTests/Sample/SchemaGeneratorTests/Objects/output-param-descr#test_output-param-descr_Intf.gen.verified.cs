//HintName: test_output-param-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
  : IGqlpModelImplementationBase
{
  ItestOutpParamDescrObject AsOutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
{
  ItestFldOutpParamDescr Field (ItestInOutpParamDescr parameter);
}

public interface ItestFldOutpParamDescr
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamDescrObject AsFldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
{
}

public interface ItestInOutpParamDescr
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestInOutpParamDescrObject AsInOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
{
  decimal Param { get; }
}
