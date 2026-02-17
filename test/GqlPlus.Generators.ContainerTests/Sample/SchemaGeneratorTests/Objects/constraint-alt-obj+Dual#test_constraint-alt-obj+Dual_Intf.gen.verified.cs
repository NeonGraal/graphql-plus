//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject? As_CnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltObjDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltObjDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  ItestAltCnstAltObjDualObject? As_AltCnstAltObjDual { get; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  decimal Alt { get; }
}
