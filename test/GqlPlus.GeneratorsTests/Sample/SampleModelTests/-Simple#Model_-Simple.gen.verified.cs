﻿//HintName: Model_-Simple.gen.cs
// Generated from -Simple.graphql+

/*
*/

namespace GqlTest.Model__Simple;

public interface IDomainDmnBoolDescr {
  bool Value { get; set; }
}
public class DomainDmnBoolDescr
  : IDomainDmnBoolDescr
{
}

public interface IDomainDmnBoolPrnt : IDomainPrntDmnBoolPrnt {
  bool Value { get; set; }
}
public class DomainDmnBoolPrnt
  : DomainPrntDmnBoolPrnt
  , IDomainDmnBoolPrnt
{
}

public interface IDomainPrntDmnBoolPrnt {
  bool Value { get; set; }
}
public class DomainPrntDmnBoolPrnt
  : IDomainPrntDmnBoolPrnt
{
}

public interface IDomainDmnEnumAll {}

public enum EnumDmnEnumAll {
  dmnEnumAll,
  enum_dmnEnumAll,
}

public interface IDomainDmnEnumAllDescr {}

public enum EnumDmnEnumAllDescr {
  dmnEnumAllDescr,
  enum_dmnEnumAllDescr,
}

public interface IDomainDmnEnumAllPrnt {}

public enum EnumDmnEnumAllPrnt {
  prnt_dmnEnumAllPrnt = PrntDmnEnumAllPrnt.prnt_dmnEnumAllPrnt,
  dmnEnumAllPrnt,
}

public enum PrntDmnEnumAllPrnt {
  prnt_dmnEnumAllPrnt,
}

public interface IDomainDmnEnumDescr {}

public enum EnumDmnEnumDescr {
  dmnEnumDescr,
}

public interface IDomainDmnEnumLabel {}

public enum EnumDmnEnumLabel {
  dmnEnumLabel,
}

public interface IDomainDmnEnumPrnt : PrntDmnEnumPrnt {}

public interface IDomainPrntDmnEnumPrnt {}

public enum EnumDmnEnumPrnt {
  enum_dmnEnumPrnt,
  prnt_dmnEnumPrnt,
}

public enum EnumDmnEnumUnq {
  enum_dmnEnumUnq,
  dmnEnumUnq,
}

public enum EnumDomDup {
  dmnEnumUnq,
  dup_dmnEnumUnq,
}

public enum EnumDmnEnumUnqPrnt {
  dmnEnumUnqPrnt = PrntDmnEnumUnqPrnt.dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt = PrntDmnEnumUnqPrnt.prnt_dmnEnumUnqPrnt,
  enum_dmnEnumUnqPrnt,
}

public enum PrntDmnEnumUnqPrnt {
  dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt,
}

public enum DupDmnEnumUnqPrnt {
  dmnEnumUnqPrnt,
  dup_dmnEnumUnqPrnt,
}

public interface IDomainDmnEnumValue {}

public enum EnumDmnEnumValue {
  dmnEnumValue,
}

public interface IDomainDmnEnumValuePrnt {}

public enum EnumDmnEnumValuePrnt {
  prnt_dmnEnumValuePrnt = PrntDmnEnumValuePrnt.prnt_dmnEnumValuePrnt,
  dmnEnumValuePrnt,
}

public enum PrntDmnEnumValuePrnt {
  prnt_dmnEnumValuePrnt,
}

public interface IDomainDmnNmbrDescr {
  decimal Value { get; set; }
}
public class DomainDmnNmbrDescr
  : IDomainDmnNmbrDescr
{
}

public interface IDomainDmnNmbrPrnt : IDomainPrntDmnNmbrPrnt {
  decimal Value { get; set; }
}
public class DomainDmnNmbrPrnt
  : DomainPrntDmnNmbrPrnt
  , IDomainDmnNmbrPrnt
{
}

public interface IDomainPrntDmnNmbrPrnt {
  decimal Value { get; set; }
}
public class DomainPrntDmnNmbrPrnt
  : IDomainPrntDmnNmbrPrnt
{
}

public interface IDomainDmnStrDescr {
  string Value { get; set; }
}
public class DomainDmnStrDescr
  : IDomainDmnStrDescr
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IDomainDmnStrPrnt : IDomainPrntDmnStrPrnt {
  string Value { get; set; }
}
public class DomainDmnStrPrnt
  : DomainPrntDmnStrPrnt
  , IDomainDmnStrPrnt
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IDomainPrntDmnStrPrnt {
  string Value { get; set; }
}
public class DomainPrntDmnStrPrnt
  : IDomainPrntDmnStrPrnt
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public enum EnumDescr {
  enumDescr,
}

public enum EnumPrnt {
  prnt_enumPrnt = PrntEnumPrnt.prnt_enumPrnt,
  enumPrnt,
}

public enum PrntEnumPrnt {
  prnt_enumPrnt,
}

public enum EnumPrntAlias {
  prnt_enumPrntAlias = PrntEnumPrntAlias.prnt_enumPrntAlias,
  val_enumPrntAlias,
  prnt_enumPrntAlias,
  enumPrntAlias = prnt_enumPrntAlias,
}

public enum PrntEnumPrntAlias {
  prnt_enumPrntAlias,
}

public enum EnumPrntDup {
  prnt_enumPrntDup = PrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup = PrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup,
}

public enum PrntEnumPrntDup {
  prnt_enumPrntDup,
  enumPrntDup = prnt_enumPrntDup,
}

public class IUnionDescr
{
  public Number AsNumber { get; }
}

public class UnionUnionDescr
  : IUnionDescr
{
  public Number AsNumber { get; set; }
}

public class IUnionPrnt
  : IPrntUnionPrnt
{
  public String AsString { get; }
}

public class UnionUnionPrnt
  : UnionPrntUnionPrnt
  , IUnionPrnt
{
  public String AsString { get; set; }
}

public class IPrntUnionPrnt
{
  public Number AsNumber { get; }
}

public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}

public class IUnionPrntDup
  : IPrntUnionPrntDup
{
  public Number AsNumber { get; }
}

public class UnionUnionPrntDup
  : UnionPrntUnionPrntDup
  , IUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class IPrntUnionPrntDup
{
  public Number AsNumber { get; }
}

public class UnionPrntUnionPrntDup
  : IPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
