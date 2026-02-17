//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp>? AsRefCnstAltObjOutp { get; }
  ItestCnstAltObjOutpObject? As_CnstAltObjOutp { get; }
}

public interface ItestCnstAltObjOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltObjOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjOutpObject<TRef>? As_RefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltObjOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjOutpObject? As_PrntCnstAltObjOutp { get; }
}

public interface ItestPrntCnstAltObjOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  ItestAltCnstAltObjOutpObject? As_AltCnstAltObjOutp { get; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  decimal Alt { get; }
}
