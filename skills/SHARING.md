# ASX Skills 安装与调用

本仓库提供一个总入口 `artemis-asx` 和 ASX01–ASX10 的十个模块 Skill。任务涉及多个模块，或还不确定该选哪个模块时，从总入口开始。已知模块时可直接调用它，完整名称见[模块索引](artemis-asx/references/module-map.md)。

## 任何能读取文件的 Agent

克隆本仓库，或让 Agent 访问仓库的 GitHub 文件。把下面这段发给 Agent，再替换最后一行的任务：

```text
请读取 ASX 指南仓库中的 skills/artemis-asx/SKILL.md，
按 module-map.md 选择模块，只读取相关模块的 SKILL.md、指南和示例。
请列出选用的 ASX 模块、运行前提和能够验证的结果。
任务：把新录音交给固定 HPSX 批处理，再检查输出 HDF 的通道和单位。
```

确定是 Add-In 的话，可以直接指定 `skills/artemis-processing-addin/SKILL.md`。支持项目规则的 Agent 也可以把这条入口路径加到项目指令中。分享时请保留所选技能的完整目录结构，并提供配套指南仓库。

## Codex

将选定的 `skills/<名称>/` 整个目录复制到目标项目的 `.agents/skills/`，或复制到用户目录 `~/.agents/skills/`。这样项目安装后入口路径是 `.agents/skills/artemis-asx/SKILL.md`。复制总入口和常用模块时，把这些目录平放在同一级。若只安装总入口，可让它从指南仓库读取其他模块。重新打开项目会话后，用 `$` 选择或直接输入技能名称。见 [Codex Skills 文档](https://learn.chatgpt.com/docs/build-skills)。

```text
$artemis-asx 请为我设计从触发录音到批处理和 PDF 导出的工作流。
$artemis-hdf-data 请检查这个 HDF 的数据类型、通道、轴和单位。
$artemis-processing-addin 请给这个 Filter Add-In 增加可配置增益，验证输出元数据。
```

## Claude Code

把完整目录复制到目标项目的 `.claude/skills/` 或用户目录 `~/.claude/skills/`，然后从聊天输入 `/artemis-asx` 或 `/artemis-processing-addin`，后面跟任务。未安装时直接使用上面的文件路径提示词。见 [Claude Code Skills 文档](https://code.claude.com/docs/en/skills)。

## 配套环境

Skill 用于选接口、写代码和规划验证。实际运行需要目标 Windows 机器上版本匹配的 ASX、模块许可证，以及任务需要的宿主、前端或测试数据。单独安装 Skill 后，请向 Agent 提供指南仓库的本地路径或 GitHub 地址。团队分享可固定到同一个 Git 提交，便于让 Skill 与示例一起更新。见[统一安装指南](../INSTALLATION.md)。
