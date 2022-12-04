using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace Problems.Advent._2022
{
    internal class Dag03 : Problem
    {
        private const string input = @"ZTmtZvZLTFNLMQMNRvZncdcHwcScJvcdHnVfwV
zqjqrzqjCqrjtqWhqChqrznhcfdfVnVSVgcffcgJcSgd
rtDGpzjjqjlrGsWqBWFRsbTPFQMTbRNRFmbs
FFlnlnVlmQqcBVhBRrSrGSwVdRJbztSt
NPPNsffWfNztRZSJNG
WpgpTTHDpgTDDpMLPGgMHslmBmmHcBQnFmcqhmnjlqQm
VlVNLlPQhtnDRPnP
QgqTffzZqgvgzWmqqZmGcDthtRFvnnFnhJtJJDDt
WGTBzSqBQTQmZBWHswpNbswLbSNCNl
PFzFQDdLjMzzQDhnDNmwZmqwRsmRRmMVNM
GtSbbtlttvvtBvtHBmqqNqVVwsVgCmRw
brlvctHfrlrqvGvcTpjDdFnLDhdfjLhQpn
fTqzgFrcmzTrTNgMzFzTrgtbMtVMVPSLVbvSStRttPVV
lsHnlQhplQpsHhlDJsswNwZPZZVNwvnSZSVvVS
BJpsGWhWQQHdGHlpWpfgrmqgNBmTTBqzTrzr
PLPPrDNHDBnrWNBmjDmjbqqgzjgjQC
GJpFwpvFFsJpwvwwGwJZJRptzdQSSZTmCjTQmTSQjjZSggQQ
ffwGGtJGCfLcNMNNfNLW
nlTzllGwlQHHGMSrrhQLcvbcghgcvL
fFNpttBRFFRNtJJnfNWmqbhhZrZrcjgpvLrvrvcvbr
JBftFFsVRWtNWRsmWtRfftGHGPDDCnTDHSCwzwVnwGSw
LsrZLbLmPSTZtPcc
zpnpljpdwhRpfNLlPWPtTPcnMWPcctTV
qlhNNjldqdpgqdfhjpphdsgmmrDBBJJQgHrmDHLQJb
ndDrsBbpqspHCjzVBCHjMj
LWFcQFQtVVdcCMHC
RLthwTWLTSLwTllRLLlLNlPpPGfrGnqDdGqsZqsZsZhb
jHnJLJrcBbrRHJpnLBBjdHbjfgvGwstwWwdsWWshfhFzFfhv
PZDQMNTMQwtgvGTGhf
lqlPPQZQVSQCPSCPDmLppjqRqHngLHjRgLnL
MfQrhdzNMfMPsNNmPmqPLCLCVLBnbP
WVtcVvJJVjvFZZmgGjnjLBjmnnHB
FFtcZRpWJcSDTwlVMhMDwrrDzM
bSMbrQGZwwqbrbGMdTQGMwQdfFBLDLHLHssDgsHHBJDsFfwL
lpPPCccvVPvccPzcWLDJFJBsBzJJHsqHjg
tnqlPlVlNvNZZSSrGGZb
NlBBBBBwmwcMgLwLVVLLLscHdnMDdbHJCbdvJbPdDDJHvn
ZRWQWSfGhtSjqZhffZhhRjtdvPFHvCJbFdCFFDdHJdPb
fpqGhQWWZRhfqRSqrpGllLcVLmscgrLwBmgCzN
wHHHwDNCzZwzZfpzwsswzfzvnvnMDMgMhMGGFGRVdMnvcF
mLtttqTPBtSJTSBQWlmcMvVdclnvhFggdGhRdn
QBLPSLQQWmLtTBtBSjZfsbwbHzpjGzHfpzzw
zDPBqBPqwzzsqlTzzPzqjttNbCPJVtPCbrvjvCZP
MFhMhGfFfGpWWpHhFfRpHjVNbDbJjVMjrVvVNtMtbt
gfRSmpggSFRgfGRphFGgfgBSBTqzSsdlTLqdsnsDBqLw
QTTdWZZZTrhCZrjhVt
SBJJNRRvvRpwwspNSpTPjCMVhhtCjGThjBjB
fJJpvRRwNRSwvzRzRvzSgSRNqFTFDbFmqncQTbdFfnbDQnLW
wSjwwjWhbhhjWjdqSVpqSndvMdmM
NTvPBrZgPPHDFrFHGvZHRBqVBpCQVRRdmpRppdqM
TgDHZPsNTWbbwsjtvw
HVRPRwJVppQNpGmvMvmqqq
WcttbWsWsdDdbFDSSWclZGvFLMvfvjfzNvLGzLmfqv
tglcmSldWlBQBThRQBhg
LDGGfPFLGsfFnGLfMzfJVccNzmcmwm
qggSRgtjgCRtdtNZCJMCcZwTZVcm
RBbHbbRRnLBDDrvN
pThhMtMtTsWspWTnGjpsVHPdjdjvHdgVvLDVVSjd
JQNrrwCFrSRLRVLnSN
JQcJFCfcnfQmrbblQqlthGqzpZpGTBMWTMqtst
DzVmzDDgsNdHHLGJhJppPPllqSgbql
jrBWjcQMCRchPShwSblpbW
ZjRrSCtnnrtBQTcrSZmGtGFFNDHmHVVmVtzz
GSbGbrTGRRScMlVFjfbqqjdF
tvDmZhtNtHDttBhCmHDJHNwlpjslMwfflvpqldsFpMlf
HdBhLDhJDLWWLDCSQGcrQPGccLTGcQ
tNzrCdJBrrtQdtgQdlQQtrnMZhMTqzHqqTFZZFqTHFMV
bwbsRDvfwfsfcfSFqMmqDqFVNMNVVH
PRvfbSjNvPWPlLllLJ
MjMRRNRMjZtGVGpBCMMCDV
vwfhFzhvcJQQwJlQSddzQwFWGqcDpCDqBqDTcGZTTVTCWG
dvFJzrfZJhddLNLPHsrtRbPr
BmbsFNBhszGgGtGl
MSHVwdSwZflGlcqqpM
QvwZCnnnSvZdCSWrNmDlPPBPDhPmjW
MDwpRzRwMzMsdVSjdMWWMQdW
gmlftnDtHnHHVWSWBjWjWgvW
HbtrhbbGRNDpbCDz
cjVGqQqVqBFhDtvB
ZnTTfTffZZmDhBtJZG
fNzbpzlHTlgHNzlRTlRNbHrWwrCwWSSdQddNjwVcjGSd
WWrPMhwhnjpSLCpDlSSW
sNGBGdmTbZNGsmbstNLZGZDBRSlqSRCfRSCqRRDDqCqp
NvvcGtsLdTNZmLTmdJPcnnMFjFMcrVJhMF
wMRQMSQZHznRsqRbWp
ddgDDhfDrrDdjthHmdHrzpbVCVWFpfVqCWpWqpFs
hdvNdHtjMLJZvJwM
nWzZtWzHzZWgQHMNLDMDfDBfQbdD
MCPmRGGhqdmNjbDN
FRPlMlRChCvFggWZsHsZHn
ZGhhjdgwgcZHsPnRnSnbWscn
tltlfMQQQftDFJpMQJsWJWJsnWBnRSBbrBWP
lfLDpQMFMNfLjGjPPgZzwh
HcmvWcqnHLLPDzPPHM
MGGSfdJRdCglfrLjrjrLzLPzlF
CsgRgfwgdCwhsssJBBwvcnQnQNMvQtQm
nrVbwgnSTSgSnrZpjpWWqmWNHlqqpV
BcBPhSdsDlHNtNlJNP
RLFCQLQRRsBDDcRdGDddhCRDfwzvSCnzrbfrMfMgznwwfbZv
HJLzLNwBNzNJLzBJztRGzQVnDgwsjbgwssZwnDZbDQ
PhvlSvvPfMRlDbDsggbSjQSg
mFfhMlMrfchvPPpFTPvMvPzLBHWRHJNtzJGzzHpzBtCC
FLsgSLzLswdFgLBbWZnJDWHcmZnnBjHM
rpbrrqfqpvCbqqQQvvpClblRDHmjmmjJJZZnWMJmmJmmcRMc
qTppQvCfhzSVVTzbdL
ThTJtlqfDrDtffwqRCFCCnLwdnmpzRdF
WPQSSFsGMgQZWvFQgZgZQcCdmmzLMLCpNzCCddmLzdzm
cvVPGPQQGsZsgGPjVFccbHhThJHhDqfhDDjHqDrr
CgnCCnPMnMtGHDbMFQ
zLpwpRTwwRwhRchHwmqmGvvGbqmTmNQqvq
sHdhzlwrRVrdLzRrprrfjgfjVBnBCfSBZZgPfJ
SPMdWwWPrZwdrrWrSPLFDfgbQDfwDFfFglDQ
qLGBtGLpjzqmvQbvvpDvfFpR
jhLqqHBLGjtLqSZCssSTZZMshP
MhJCpPDpRRFRzQQNNqbcZjNZmVhjNm
LLSlLnGDmNqLbNjb
sfBngrBSTTSnSGHlTsHBGsBpFFdRdQPDCFPWRMzzdQWM
ZQtmgtWfPcgPgcsb
pvMhFThpHVTvPbcFcFJLJDsd
MTVHchVVHjHHTcpjMVBjjnQnGqQZnlqBmrWQQBffQQ
HfcRNJpJfhCmpGSqqGNjsjBnQl
tTdPwwtLTrrTVPSnQsbGPsnnlFllFQ
VvvTSTwWMrSZVwwrrmRmczJchHcHCZhRzD
wfRwhmLRnvrHqHhV
bJlBHlWlHMBPJzDlzMMJJSBlFnrGVrqspGGvpVGPVpGsVqvp
DWdStDMztCCHgZCtmZ
MHdsznVDDfcjcjDcdDjmMSCQwQpCpFCvqSZQqFzQpQ
lhJnLJJnTNrWTRqvqqPrFwZvwqQp
NghhtJBtnWLRTNjmcMDtjdsMfGDH
jgsvPffVmHfDqPSrNwnQwnwNhSvw
PZbGbCdcGdRCGtntQLQQLLwtpLNw
RbcPFBRFcdZBBJDBmTHjsD
dTTFJdzhmmmQpzVz
jtNLcctGGjtfrnVMsNQNQVVWnv
GcrcrfLtDggLftDFhZFdJFHJBVFBgZ
TTbqTgqCqZCrwmhQnnmrgh
MhpfsMLhfmrznLrQrF
RsStRMtjpHMfDtWsWsNDppsqlZqBlhNlbcNdTPClPqcvBP
lRhZPgnpRGZlSrmsLSvSzLVl
wwHdHCfDQCJHdwdDMdHCcDsLmNVvzVsWrcVNcVzLbrLz
dMCCwCtJdwDQJMtjhnvhpPhRZBhR
pBqMZfDffmBnvnNmPt
rhwLHCChrLPCMNWMCNmW
GSMVRSVwHLMRJDQJTZlJZR
sfstzPGRRBSngMfQLNNqgWLQLZZNgq
scVDjjjCDTVhHlDhHdvvjwjHrZmWQmJmrJJWqNqLJbrcQqZq
VvHlVHldTjvhpVplhVThhwjlPFSzPfGzpGBnsRffRRBPPGGF
WNFNfnWTSLSJTnWShTvVZCnvrdPrZvddVCrt
QwsMjppcpHCPdHsvPZ
lcwMGgpcGbzQpMgQwbDjDQZSJTRfShffWNJSSNFFbhSb
JDNgTgqDTggQbQGbZDWbJmVJrPVfPjlPfPwlljJC
FZzHFSznZZtptHzcSmCVrwfPVcwwVrCcdm
nMSStvnZFSHpLLtBtMzHnMWQvNhgDgGNRGNhgqRWTgqg
SJcrhvbBLBLrDpllvnwHQRnllHnQ
ffsjfMMZfVdCCgCfgTzmzslRtwFwFtTnqqHTJRQnqRqq
CVPgmdggVjCJSrhrbrPrrSLW
LPtcLtgddLMRRCMRpTBRrZnppvvGRvBw
WNNJjDjqSjJSqWqzNqzlSlBTGGFvrppSrwTFpn
qbNDWNNHbJqVtctwVmsfLCLP
FvSSLMqgvVSQjQfgwpwWpj
BthszRPRRNbNtzmHRbHNRNPfwJGcsswWQpffJpfsJcQFwJ
bBtzPmRrbBRHtNCzPhqdCLFMLSSvdnvCTnML
VPHWJPDjVLDDjDSFDJhgdnNGdbblzTzNjlnNbl
ZprsRZMQwwmGZsvtQZgTfggqnbfdTzrbqlTd
GZMtsscmsRZswwBQHBhDDJJPPCPWSWCJ
mNDNNmmVMSVgGgGGqsqGLhQqsLGhLq
nZBTZpJPhCpnnrsqbbcfczJfFccz
HpBZZRPRHjnPPjrHnRtCZnBdShDVlMDNDgVmtmDdVDWSdN
tBftztmztGBBCBSGHBmhvHHcchbshhThpbLJHJ
wwzMrrMnQdldVdMvJTcLNnphphbLJv
ZzwPVrWQlwrdStGGCWqDSSGW
QwfrQPvhwPfzQrvWWpQpvVGGTDGsjbgNNcbfsGTsDFgG
CtddSdZMRRdnJhRnHtZtlRMbGGDjDgggjNTZDNgTGFgGjc
mdmdCnHhVWmLmwwL
zLcWSWFcPJLWrWLSZrJLjVjHtjVsrdtstHdtVQgg
nChlwwnmhlCNqhhjHMgDjVVdwMjdtd
CNnBmNNThhhdhCdlBGGlGvNpcJbJLSbcZzcFJzpJTWPbzc
LdPZTPVpLCVTtCNsNsfFnlDC
SMwqcqcWQMbMhWQzBnsNfsFwrnnNNlrs
WMMWhvQRNNNjvLgZ
DWFGzrtfsZHZZMLt
pNwNzNCNTpppmnvNMTLVjHLBLLjMRTLH
PPdlPmJJNNClDdcdDDfWhzrW
nSJVSHQQnwLThnhrML
ddsjfRdGZjmGjRTwwTZhwrMwWwtb
qCdfRdMmgssPfjsdjdPspBzQpScSSCBpzNBQzcQz
fJnmRMJrlrmRmTRmbqssWVdqNVQdswdNNb
GZggFHGhHHgHSFvtHPPPsfwgwNsVqjqNpNjNNssN
PPSPDDBPBmBMlLfmLr
BdqdCBqqCVPVTZBrlJcTcTJTcfcbwwmcgv
WjGGLzLMhpWQmRGhpHfbhcDhHHHhgcsbJD
tQzSGjWRzWBntntrZmVB
clfLQLgfzfTLDMwNrNrrNDGCGG
tmbpFtBvvmvdQQdFQwMJCG
SnbtnqnSbnQQsBqzgLgVsLZTLTPfVg
QnQBQQBVzqqzpmfgBpnqSDFPjhhWsFVhlsFFsDstFs
MGGrTHcvRTTrrrCDpjvWtFPlFlsvjp
bZbpTpJJBBQmBmJf
dNVgDdVtPcNPhgTLPLpTPlnTHHRn
WrvjvwjWwfwWjGJsrwBjQJjTQLbnSTTmpTRQSTClHTbLmn
JqWWGvBJBwGJfJJGvwqZZddFtDFhgDqZhHNM
VwJcNgbfvfJbfcmGLZfPhZLfZGTDhP
CnnrlBlprsBnzQFntnZLqDhZZqThWGtWWSPL
FllFdCjzlsCzjJNJGGJwHHVg
fTbVBmNJCJRVbTmbfJFHsDjQHDHQjnQRsvDn
cLWcrGtttddMPhrPhPtPrtzsnSQQBvHjFpFSpDHsMjnvjD
PrPgPdhGWLrrqgdqcVCffbNblBwfVmwqwC
gmBfbmlbBDqrdfrDcJ
PwVWrQphQWWhQsJFcMPqzDdcJq
QWCSSHpSQWCttQpCRCHNSlZBtrmBZTjvGgZjmBZjBn
JrnhMPvtVtPVHJGrBrQwTmQmRGGB
pSSZCFClCbbSLbljZlSlFFszzBwcZNwTzQNDmBwGTBNTBz
ldsCCjpFjCqdLgsFjpsLFQgtnfqtJvnMtnvhWnHHMnnVWV
hzNHzHjWNzwHjjhprpGvGgvGvvpv
PLBVVRPDLdrgCdMrdrdC
FmBTqTmLPrsFqTBDcTTVtNNJztqWQNQtWWtJqNNz
fFffFvFBgHQWHdvfGglBWbqbPSSbSwVntPhZwwbS
jJCMzNMCjNCLNMjjphPSPqhbqnwPZLSqZh
rNpJJDzpcNMzzdBnGcQTccBvgv
FRFMwsrzVtwstgbCHHJJPgNb
hfZGhZDnnTTHTCCNzJjH
hppDvznmZphZQVFQwFVWlRqFls
jrjrgdHdFBZsBlcCGghWNgpgbCCp
QwJJqQQMLwPTwLMMwzvzwwzhCWbvcNcCChWpchWbNGfFff
qqFQJTmwJSPjZsrlnBjdHm
QfffRppWfHpQSrWVpSGmGMMccSjBjmmGmc
qdzLvbwzwdsWwnFdBBcBhMjMDvBBcBhc
bPdZPqddqzFsZVRptZZQHVWNpN
BzBQQHNjTSzzJDDFZFgJDJ
qLvCnLpfCpqCnLJhntRglFncDrGrllmZFZlDrc
JpqvfhRhLddfpbbtsdJWjHSwHHTNSQNPTVHQTb
qVQCCVlQZWgHZMqgqWlrtScFwrmtmcJqSSsSJS
MzdnddpNLzhRpzbzNPPBbPScjcnmrwSFjSjSJFtrwjcF
ddTzRMPLdLbvhBRdLWGQClVVCWQZQDTGGf
DHHTsldDNdPnVDCRDCNHllHwcMpprSMpRmphhRWhrhmzSS
qJLBqQLvJLQgftgPjJrhrMMWSmWMmMrrSqrc
FjfFftgLBjJPBLQZGvvZtNClnTTNGCdHTbCCNsnslH
jHHNsNqhjsShsshdRRCDMfMbCWHBrGGC
TJQFmnpgmTpBDCgCMCDZCGDC
FwpQzwQTmVvwTJmFJzTcQSdhBNztNPNjSlqLhBNhSh
vBCfSDcRMfRcRHSRRZZtPwrWWNtdSmrNVGSdwm
gbLnTzqTbjhGqFzgWrtttQtrPQTtNPmP
zbhjzglgzzlBGcsflsCl
jNHDNNHjVGVDNQFDTQSFZzDQTd
vvLwhbnpvPPgClwnfFTmTZQgffFFtTfc
LrhrLvwrnJvhCHVVRZNMjsRJVB
ShfcBWfvdhhJBBVwCJjHTRNwRVNC
qQzlDqMDDDslPqGVLTNZVpPwTRZZpV
bgbDbsqzsDTcfrgFFdgg
vlRHvvHwvMMMTTlvjmRtBjSJmSnDnpdrpSSrJJnDQrLp
cPfCgZZzNzzcGhNszcTPNZLrnVSJpJhDrrhSSQSpDDQn
FbTgbGcgNgcFbPFHMqvjjRtjRWvFvt
fZTnqfFFDNglcjdjZcfLGQJBwrGGQwbGQTBBJz
VhvfvsPpWRChmphvRGBbBLGhSbLrBQBSwb
pCsCsHvsstPsfRMMMtmDqFjngdFZqDHFnNFFjl
PVVwffMlfGWMDDSwfDwVpRpsZRjBHgpSsjJSpBSp
TdnFbqTFdmbjctcqcbRBZtJJZgsBzBBzvgHJ
bNmbcqnnbNFLChCVCfjDfWlMjVDPCr
JBLLjBQccLLJhcBDDlSrdFDsVhrVsR
HgNWCgqWGbvCRRZvGWvZmszsSlrWdSdFrWzSldDF
qvGCZGHggRNHvGTgvLnBjpjjPJwTPjLcJj
GCGwQrwBZMZdGVdLzbqbbp
TRfTTCtgcDmhtDmsTDVSbvpLdNpzNVRqVdVL
CfDJjscgTcsjfhtFZljPZWZMWPlZjQ
WsrjjfRfjjZjwjWjBpDpVpVhMBsMMSBT
JgmqHnCHHPCCtCJgSZMgZppDTgzvzZMz
HCGCGqqqCtmnHnqLFHWjlFrWRRbfjZccNWrR
BJBfSfPLPvdhvrbbvpDsHgDTzgpdzgZpgN
cVcmRnCWCqGngHpZsZsTsqNN
jmGCVwWjjnWFMjGwcwmrLJbBJPbLSrPPTbFBTr
SPZmmtlmqjZlZMwhlrtggqGGcCLCpfGLgqdCqF
FBBVDVTVDJfgcddLCDdp
zzVHvVNTbWJJTTRbVWBFJbWHmwmSPlMjPSShjlhMhhrrml
GJZJZTsnhsDJtVZdtsZJZrBCQpLjQgBnrQgjCjQQQj
RPSfqcRShHbFcPSfBqLLprBCwrQQQCqg
zPzPRHbFPcRRRHPclMhSfvfZsJZVTTZsJNVMGWGVdGTWWD
lCZrCLWCwVllGzWPPBMTFpsbGdsTpsbNMgFb
RDjtjHcHjcHctDRtjnhtnHTgMqTMqhTbdbdZbgFqZdMN
vfDmvfjtmvtcHmjZfSRZHQzBLrVLCJLJLfJBPzVJlwPw
JMTHVZMWNSCwCwMS
nsddQbDCnQQdDBPdCQCSvwpDvwffhfSvpmppvp
BssqBFtqRHgTqVRC
cWTTthtrgrzpCdCddtpz
SSSLNJLGLSLfCJfJFQCJzQ
swMPMZVMMSlMSZMqVSSHznzcqgzWTHgTnhbnrr
RJjjgMjWShPqchtbVBPV
DDddwCnZMHLLvDnfLrvvbVbbBtpwVBVPwtVpbcbb
zrvnvLrlZCHrfZZLffHZHHTsTmsQgFQSFTMjjQlFTRmR
zhTTMLRVTzLbVqwVRJgDQQsSCgCDNgsZCpqp
rrmrBmmWrWnHjWnGWrnGnhDHSQgNSpQsCgSNgtNtDDHZ
fBrGPGmGPBcTMfLhJVTc
TbTCjTBSbCncHsDZDZPhZbzv
rMwplFdlWWJMJzhhpGtHtvHSSP
fMMfwWdWrNfJNdlVgMcTLTmLffjTqnLScCjL
SwhTllwJDwqqBWLBbNtfhjBB
mvllZMmRMZGFZRfctLWtWttzfNLR
MGvHMCGpVnFGlgvVFFnpnGmmsHrDJJdSsqPqJSqDJJdTTDqD
QTTcqJZJhHSpShhFpFzjDDwwsFzpdg
NBMnBvmBPvwrqvgvvqgD
bNNGmWmbbClQTQRqchhQbf";


        private const string testinput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
        public override Task ExecuteAsync()
        {
            long total = 0;
            long total2 = 0;
            IList<string> group = new List<string>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                var l = line.Length;
                var r = (line.Substring(0,l/2), line.Substring(l/2));
                var intersect = r.Item1.Intersect(r.Item2);
                foreach (var c in intersect.Distinct())
                {
                    total += CharValue(c);
                }
                group.Add(line);
                if (group.Count == 3)
                {
                    var counter = new Counter<char>();
                    foreach (var rucksack in group)
                    {
                        foreach (var c in rucksack.Distinct())
                        {
                            counter[c]++;
                        }
                    }

                    var badge = counter.Keys.Single(k => counter[k] == 3);
                    total2 += CharValue(badge);

                    group = new List<string>();
                }
            }
            

            Result = (total,total2).ToString();
            return Task.CompletedTask;
        }

        private static long CharValue(char c)
        {
            long s = 0;
            if (c >= 97)
            {
                s += c - 96;
            }
            else
            {
                s += c - 38;
            }

            return s;
        }

        public override int Nummer => 202203;
    }
}
