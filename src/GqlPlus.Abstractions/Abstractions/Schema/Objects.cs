namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject<TBase, TField>
  : IGqlpType<TBase>
  where TBase : IGqlpObjectBase<TBase>
  where TField : IGqlpObjectField<TBase>
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
  IEnumerable<TField> Fields { get; }
  IEnumerable<IGqlpAlternate<TBase>> Alternates { get; }
}

public interface IGqlpObjectRef
  : IGqlpDescribed
{
  string? TypeName { get; }
  IGqlpDualBase? Dual { get; }
}

public interface IGqlpObjectBase<TBase>
  : IGqlpDescribed
{
  bool IsTypeParameter { get; }
  IEnumerable<TBase> TypeArguments { get; }
}

public interface IGqlpObjectField<TBase>
  : IGqlpAliased, IGqlpModifiers
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpAlternate<TBase>
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
  IEnumerable<IGqlpModifier> Collections { get; } // Optional is invalid
}

public interface IGqlpDual
  : IGqlpObject<IGqlpDualBase, IGqlpDualField>
{ }

public interface IGqlpDualBase
  : IGqlpObjectBase<IGqlpDualBase>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjectField<IGqlpDualBase>
{ }

public interface IGqlpInput
  : IGqlpObject<IGqlpInputBase, IGqlpInputField>
{ }

public interface IGqlpInputBase
  : IGqlpObjectBase<IGqlpInputBase>
{
  string Input { get; }
}

public interface IGqlpInputField
  : IGqlpObjectField<IGqlpInputBase>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpOutput
  : IGqlpObject<IGqlpOutputBase, IGqlOutputField>
{ }

public interface IGqlpOutputBase
  : IGqlpObjectBase<IGqlpOutputBase>
{
  string Output { get; }
  string? EnumValue { get; }
}

public interface IGqlOutputField
  : IGqlpObjectField<IGqlpOutputBase>
{ }

public interface IGqlpInputParameter
  : IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
